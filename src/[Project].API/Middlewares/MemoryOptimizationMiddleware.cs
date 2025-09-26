using System.Diagnostics;

namespace _Project_.API.Middlewares;

public class MemoryOptimizationMiddleware : IMiddleware
{
    private readonly ILogger<MemoryOptimizationMiddleware> _logger;
    private static long _lastGcTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    private static readonly TimeSpan GcInterval = TimeSpan.FromMinutes(5); // Run GC every 5 minutes

    public MemoryOptimizationMiddleware(ILogger<MemoryOptimizationMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        finally
        {
            // Monitor memory usage
            var memoryBefore = GC.GetTotalMemory(false);
            var gen0Collections = GC.CollectionCount(0);
            var gen1Collections = GC.CollectionCount(1);
            var gen2Collections = GC.CollectionCount(2);

            // Log memory statistics if significant collections occurred
            if (gen0Collections > 0 || gen1Collections > 0 || gen2Collections > 0)
            {
                _logger.LogInformation("GC Statistics - Gen0: {Gen0}, Gen1: {Gen1}, Gen2: {Gen2}, Memory: {Memory} bytes",
                    gen0Collections, gen1Collections, gen2Collections, memoryBefore);
            }

            // Periodic memory optimization
            var currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            if (currentTime - _lastGcTime > GcInterval.TotalMilliseconds)
            {
                var memoryBeforeGc = GC.GetTotalMemory(false);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                
                var memoryAfterGc = GC.GetTotalMemory(false);
                var memoryFreed = memoryBeforeGc - memoryAfterGc;
                
                _logger.LogInformation("Periodic GC completed. Memory freed: {MemoryFreed} bytes", memoryFreed);
                _lastGcTime = currentTime;
            }

            // Add memory headers for monitoring
            context.Response.Headers.Append("X-Memory-Usage", GC.GetTotalMemory(false).ToString());
        }
    }
}

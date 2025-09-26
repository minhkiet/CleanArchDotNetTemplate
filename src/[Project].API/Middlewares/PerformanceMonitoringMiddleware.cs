using System.Collections.Concurrent;
using System.Diagnostics;
using Microsoft.Extensions.Caching.Memory;

namespace _Project_.API.Middlewares;

public class PerformanceMonitoringMiddleware : IMiddleware
{
    private readonly ILogger<PerformanceMonitoringMiddleware> _logger;
    private readonly IMemoryCache _cache;
    private static readonly ConcurrentDictionary<string, long> _requestCounts = new();
    private static readonly ConcurrentDictionary<string, long> _totalResponseTime = new();

    public PerformanceMonitoringMiddleware(ILogger<PerformanceMonitoringMiddleware> logger, IMemoryCache cache)
    {
        _logger = logger;
        _cache = cache;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var stopwatch = Stopwatch.StartNew();
        var path = context.Request.Path.Value ?? string.Empty;
        var method = context.Request.Method;

        try
        {
            await next(context);
        }
        finally
        {
            stopwatch.Stop();
            var responseTime = stopwatch.ElapsedMilliseconds;
            
            // Log slow requests
            if (responseTime > 1000) // Log requests taking more than 1 second
            {
                _logger.LogWarning("Slow request detected: {Method} {Path} took {ResponseTime}ms", 
                    method, path, responseTime);
            }

            // Update performance metrics
            var key = $"{method}:{path}";
            _requestCounts.AddOrUpdate(key, 1, (_, count) => count + 1);
            _totalResponseTime.AddOrUpdate(key, responseTime, (_, total) => total + responseTime);

            // Log performance metrics every 100 requests
            if (_requestCounts[key] % 100 == 0)
            {
                var avgResponseTime = _totalResponseTime[key] / _requestCounts[key];
                _logger.LogInformation("Performance metrics for {Key}: {RequestCount} requests, avg {AvgResponseTime}ms", 
                    key, _requestCounts[key], avgResponseTime);
            }

            // Add performance headers
            context.Response.Headers.Append("X-Response-Time", $"{responseTime}ms");
            context.Response.Headers.Append("X-Request-ID", context.TraceIdentifier);
        }
    }
}

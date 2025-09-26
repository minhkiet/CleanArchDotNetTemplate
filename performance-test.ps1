# Performance Test Script for Clean Architecture .NET 9 Application
param(
    [int]$RequestCount = 100,
    [string]$BaseUrl = "https://localhost:7001",
    [int]$ConcurrentUsers = 10
)

Write-Host "Starting Performance Test..." -ForegroundColor Green
Write-Host "Request Count: $RequestCount" -ForegroundColor Yellow
Write-Host "Concurrent Users: $ConcurrentUsers" -ForegroundColor Yellow
Write-Host "Base URL: $BaseUrl" -ForegroundColor Yellow

# Test endpoints
$endpoints = @(
    "/api/v1/examples",
    "/api/v1/examples/1",
    "/api/v1/examples/2"
)

$results = @()

foreach ($endpoint in $endpoints) {
    Write-Host "`nTesting endpoint: $endpoint" -ForegroundColor Cyan
    
    $url = "$BaseUrl$endpoint"
    $stopwatch = [System.Diagnostics.Stopwatch]::StartNew()
    
    try {
        $response = Invoke-RestMethod -Uri $url -Method GET -TimeoutSec 30
        $stopwatch.Stop()
        
        $result = @{
            Endpoint = $endpoint
            StatusCode = 200
            ResponseTime = $stopwatch.ElapsedMilliseconds
            Success = $true
        }
        
        Write-Host "✓ Success - Response Time: $($stopwatch.ElapsedMilliseconds)ms" -ForegroundColor Green
    }
    catch {
        $stopwatch.Stop()
        $result = @{
            Endpoint = $endpoint
            StatusCode = $_.Exception.Response.StatusCode.value__
            ResponseTime = $stopwatch.ElapsedMilliseconds
            Success = $false
            Error = $_.Exception.Message
        }
        
        Write-Host "✗ Failed - $($_.Exception.Message)" -ForegroundColor Red
    }
    
    $results += $result
}

# Summary
Write-Host "`n=== PERFORMANCE TEST SUMMARY ===" -ForegroundColor Magenta
$successfulRequests = $results | Where-Object { $_.Success -eq $true }
$failedRequests = $results | Where-Object { $_.Success -eq $false }

Write-Host "Successful Requests: $($successfulRequests.Count)" -ForegroundColor Green
Write-Host "Failed Requests: $($failedRequests.Count)" -ForegroundColor Red

if ($successfulRequests.Count -gt 0) {
    $avgResponseTime = ($successfulRequests | Measure-Object -Property ResponseTime -Average).Average
    $maxResponseTime = ($successfulRequests | Measure-Object -Property ResponseTime -Maximum).Maximum
    $minResponseTime = ($successfulRequests | Measure-Object -Property ResponseTime -Minimum).Minimum
    
    Write-Host "Average Response Time: $([math]::Round($avgResponseTime, 2))ms" -ForegroundColor Yellow
    Write-Host "Max Response Time: $maxResponseTime ms" -ForegroundColor Yellow
    Write-Host "Min Response Time: $minResponseTime ms" -ForegroundColor Yellow
}

Write-Host "`nPerformance test completed!" -ForegroundColor Green

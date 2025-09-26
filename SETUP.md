# 🚀 Hướng dẫn cài đặt chi tiết

## 📋 Yêu cầu hệ thống

### Phần mềm cần thiết
- **.NET 9 SDK** ([Download](https://dotnet.microsoft.com/download/dotnet/9.0))
- **Visual Studio 2022** hoặc **VS Code** với C# extension
- **Git** ([Download](https://git-scm.com/downloads))
- **SQLite** (được tích hợp sẵn với .NET)

### Kiểm tra cài đặt
```bash
# Kiểm tra .NET version
dotnet --version

# Kiểm tra Git
git --version
```

## 🔧 Cài đặt từng bước

### Bước 1: Clone Repository
```bash
# Clone repository
git clone <repository-url>
cd CleanArchDotNetTemplate

# Kiểm tra cấu trúc project
ls -la
```

### Bước 2: Restore Dependencies
```bash
# Restore tất cả packages
dotnet restore

# Kiểm tra dependencies
dotnet list package
```

### Bước 3: Cấu hình Database
```bash
# Tạo database và chạy migrations
dotnet ef database update --project src/[Project].Persistence --startup-project src/[Project].API

# Kiểm tra database đã tạo
ls *.db
```

### Bước 4: Build Solution
```bash
# Build toàn bộ solution
dotnet build

# Build với configuration Release
dotnet build --configuration Release
```

### Bước 5: Chạy ứng dụng
```bash
# Chạy API
dotnet run --project src/[Project].API

# Hoặc chạy với specific port
dotnet run --project src/[Project].API --urls "https://localhost:7001"
```

## 🌐 Truy cập ứng dụng

### Swagger UI
- **URL**: `https://localhost:7001/swagger`
- **Mô tả**: API documentation và testing interface

### API Endpoints
- **Base URL**: `https://localhost:7001/api/v1`
- **Examples**: `https://localhost:7001/api/v1/examples`

## 🔍 Kiểm tra cài đặt

### Test API cơ bản
```bash
# Test health check
curl -k https://localhost:7001/api/v1/examples

# Test với PowerShell
Invoke-RestMethod -Uri "https://localhost:7001/api/v1/examples" -Method GET
```

### Performance Test
```powershell
# Chạy performance test
.\performance-test.ps1

# Test với nhiều requests
.\performance-test.ps1 -RequestCount 100 -ConcurrentUsers 10
```

## 🛠️ Cấu hình nâng cao

### Database Configuration
Cập nhật `appsettings.json`:
```json
{
  "DatabaseSettings": {
    "ConnectionString": "Data Source=Production.db;Cache=Shared"
  }
}
```

### Performance Tuning
```json
{
  "Performance": {
    "EnableDetailedErrors": false,
    "EnableSensitiveDataLogging": false,
    "CommandTimeout": 60,
    "MaxRetryCount": 5
  }
}
```

### Memory Optimization
```json
{
  "Memory": {
    "EnableGcOptimization": true,
    "GcIntervalMinutes": 3,
    "LogMemoryStats": true
  }
}
```

## 🐛 Troubleshooting

### Lỗi thường gặp

#### 1. Port đã được sử dụng
```bash
# Tìm process sử dụng port
netstat -ano | findstr :7001

# Kill process
taskkill /PID <process-id> /F
```

#### 2. Database connection failed
```bash
# Xóa database cũ
rm *.db

# Tạo lại database
dotnet ef database update --project src/[Project].Persistence --startup-project src/[Project].API
```

#### 3. Build failed
```bash
# Clean solution
dotnet clean

# Restore packages
dotnet restore

# Rebuild
dotnet build
```

#### 4. Performance issues
```bash
# Kiểm tra memory usage
dotnet run --project src/[Project].API --environment Production

# Monitor với performance counters
dotnet-counters monitor --process-id <pid>
```

## 📊 Monitoring & Logging

### Application Logs
```bash
# Xem logs real-time
dotnet run --project src/[Project].API --environment Development

# Logs sẽ hiển thị:
# - Performance metrics
# - Memory usage
# - Slow requests
# - GC statistics
```

### Performance Headers
Mỗi response sẽ có headers:
- `X-Response-Time`: Response time (ms)
- `X-Request-ID`: Unique request ID
- `X-Memory-Usage`: Current memory usage (bytes)

## 🔒 Security Configuration

### HTTPS
```json
{
  "Kestrel": {
    "Endpoints": {
      "HttpsInlineCertFile": {
        "Url": "https://localhost:7001",
        "Certificate": {
          "Path": "cert.pfx",
          "Password": "password"
        }
      }
    }
  }
}
```

### CORS
```csharp
// Trong Program.cs
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
```

## 🚀 Deployment

### Docker
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "[Project].API.dll"]
```

### IIS Deployment
```bash
# Publish cho IIS
dotnet publish -c Release -o ./publish

# Copy files to IIS directory
xcopy ./publish C:\inetpub\wwwroot\YourApp /E /I
```

## 📈 Performance Optimization

### Database Indexing
```sql
-- Tạo indexes cho performance
CREATE INDEX IX_Examples_Name ON Examples(Name);
CREATE INDEX IX_Examples_Status ON Examples(Status);
```

### Caching Strategy
```csharp
// Implement caching
services.AddMemoryCache();
services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
});
```

## 🧪 Testing

### Unit Tests
```bash
# Chạy unit tests
dotnet test

# Chạy với coverage
dotnet test --collect:"XPlat Code Coverage"
```

### Integration Tests
```bash
# Chạy integration tests
dotnet test --filter Category=Integration
```

### Load Testing
```bash
# Sử dụng Apache Bench
ab -n 1000 -c 10 https://localhost:7001/api/v1/examples

# Sử dụng PowerShell script
.\performance-test.ps1 -RequestCount 1000 -ConcurrentUsers 50
```

## 📚 Tài liệu bổ sung

- [.NET 9 Performance](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9)
- [Entity Framework Performance](https://docs.microsoft.com/en-us/ef/core/performance/)
- [ASP.NET Core Performance](https://docs.microsoft.com/en-us/aspnet/core/performance/)
- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

---

💡 **Tip**: Để có hiệu suất tốt nhất, hãy chạy ứng dụng với configuration `Release` và monitor performance metrics thường xuyên!

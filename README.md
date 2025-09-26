# Clean Architecture .NET 9 Template

🚀 **Template ứng dụng Clean Architecture với .NET 9, được tối ưu hóa hiệu suất và quản lý bộ nhớ**

## 📋 Tổng quan

Đây là template ứng dụng Clean Architecture được xây dựng với .NET 9, bao gồm các tính năng tối ưu hóa hiệu suất và quản lý bộ nhớ thông minh. Template này cung cấp một kiến trúc sạch, có thể mở rộng và dễ bảo trì.

## 🏗️ Kiến trúc

```
src/
├── [Project].API/              # Web API Layer
├── [Project].Application/      # Application Layer (Use Cases)
├── [Project].Domain/           # Domain Layer (Entities, Value Objects)
├── [Project].Infrastructure/  # Infrastructure Layer (External Services)
├── [Project].Persistence/     # Data Access Layer
├── [Project].Contracts/       # Shared Contracts (DTOs, Messages)
└── [Project].Presentation/    # Presentation Layer (Endpoints)
```

## ✨ Tính năng chính

### 🎯 Clean Architecture
- **Separation of Concerns**: Tách biệt rõ ràng các layer
- **Dependency Inversion**: Dependency injection pattern
- **SOLID Principles**: Tuân thủ các nguyên tắc SOLID
- **Domain-Driven Design**: Thiết kế theo domain

### ⚡ Performance Optimizations
- **Entity Framework Core**: Tối ưu hóa queries và connection pooling
- **Memory Management**: Tự động garbage collection và memory monitoring
- **Performance Monitoring**: Real-time performance tracking
- **Caching**: Memory cache cho hiệu suất tốt hơn

### 🛡️ Enterprise Features
- **CQRS Pattern**: Command Query Responsibility Segregation
- **MediatR**: Mediator pattern cho loose coupling
- **FluentValidation**: Validation mạnh mẽ
- **Exception Handling**: Global exception handling
- **API Versioning**: Hỗ trợ versioning API
- **Swagger Documentation**: API documentation tự động

## 🚀 Cài đặt

### Yêu cầu hệ thống
- **.NET 9 SDK** hoặc mới hơn
- **Visual Studio 2022** hoặc **VS Code**
- **SQLite** (được tích hợp sẵn)

### Bước 1: Clone repository
```bash
git clone <repository-url>
cd CleanArchDotNetTemplate
```

### Bước 2: Restore dependencies
```bash
dotnet restore
```

### Bước 3: Cập nhật database
```bash
dotnet ef database update --project src/[Project].Persistence --startup-project src/[Project].API
```

### Bước 4: Chạy ứng dụng
```bash
dotnet run --project src/[Project].API
```

## 🔧 Cấu hình

### Database Settings
Cập nhật connection string trong `appsettings.json`:

```json
{
  "DatabaseSettings": {
    "ConnectionString": "Data Source=YourDatabase.db"
  }
}
```

### Performance Settings
Cấu hình hiệu suất trong `appsettings.json`:

```json
{
  "Performance": {
    "EnableDetailedErrors": false,
    "EnableSensitiveDataLogging": false,
    "CommandTimeout": 30,
    "MaxRetryCount": 3,
    "MaxRetryDelay": "00:00:30"
  },
  "Memory": {
    "EnableGcOptimization": true,
    "GcIntervalMinutes": 5,
    "LogMemoryStats": true
  }
}
```

## 📊 Monitoring & Performance

### Performance Monitoring
Ứng dụng tự động theo dõi:
- **Response Time**: Thời gian phản hồi của mỗi request
- **Slow Requests**: Cảnh báo requests chậm hơn 1 giây
- **Memory Usage**: Theo dõi sử dụng bộ nhớ
- **GC Statistics**: Thống kê garbage collection

### Response Headers
Mỗi response sẽ bao gồm:
- `X-Response-Time`: Thời gian xử lý request (ms)
- `X-Request-ID`: ID duy nhất của request
- `X-Memory-Usage`: Sử dụng bộ nhớ hiện tại (bytes)

### Performance Testing
Chạy script test hiệu suất:

```powershell
# Test cơ bản
.\performance-test.ps1

# Test với nhiều requests
.\performance-test.ps1 -RequestCount 1000 -ConcurrentUsers 50
```

## 🛠️ Sử dụng

### API Endpoints

#### Examples API
```http
GET    /api/v1/examples          # Lấy danh sách examples
GET    /api/v1/examples/{id}     # Lấy example theo ID
POST   /api/v1/examples          # Tạo example mới
PUT    /api/v1/examples/{id}     # Cập nhật example
DELETE /api/v1/examples/{id}     # Xóa example
```

### Swagger Documentation
Truy cập Swagger UI tại: `https://localhost:7001/swagger`

### Example Usage

#### Tạo Example mới
```http
POST /api/v1/examples
Content-Type: application/json

{
  "name": "Example Name",
  "description": "Example Description",
  "status": "Active"
}
```

#### Lấy danh sách Examples
```http
GET /api/v1/examples?page=1&pageSize=10&sortBy=name&sortDirection=asc
```

## 🏗️ Phát triển

### Thêm Use Case mới

1. **Tạo Command/Query** trong `[Project].Application/UseCases/V1/`
2. **Tạo Handler** cho Command/Query
3. **Tạo Endpoint** trong `[Project].Presentation/Endpoints/V1/`
4. **Đăng ký Endpoint** trong `MiddlewareExtensions.cs`

### Thêm Entity mới

1. **Tạo Entity** trong `[Project].Domain/Entities/`
2. **Tạo Configuration** trong `[Project].Persistence/Configurations/`
3. **Thêm DbSet** vào `AppDbContext`
4. **Tạo Migration**: `dotnet ef migrations add <MigrationName>`

### Thêm Repository

1. **Tạo Interface** trong `[Project].Application/Interfaces/Repositories/`
2. **Implement Repository** trong `[Project].Persistence/Repositories/`
3. **Đăng ký Service** trong `ServiceCollectionExtensions.cs`

## 📈 Performance Tips

### Database Optimization
- Sử dụng `AsNoTracking()` cho read-only queries
- Implement pagination cho large datasets
- Sử dụng indexes phù hợp
- Tránh N+1 queries

### Memory Management
- Dispose objects đúng cách
- Sử dụng `using` statements
- Tránh memory leaks
- Monitor GC statistics

### Caching Strategy
- Cache frequently accessed data
- Implement cache invalidation
- Sử dụng appropriate cache expiration
- Monitor cache hit rates

## 🧪 Testing

### Unit Tests
```bash
dotnet test
```

### Integration Tests
```bash
dotnet test --filter Category=Integration
```

### Performance Tests
```bash
.\performance-test.ps1 -RequestCount 1000
```

## 📚 Tài liệu tham khảo

- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [.NET 9 Documentation](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [MediatR](https://github.com/jbogard/MediatR)
- [FluentValidation](https://fluentvalidation.net/)

## 🤝 Đóng góp

1. Fork repository
2. Tạo feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Tạo Pull Request

## 📄 License

Distributed under the MIT License. See `LICENSE` for more information.

## 📞 Hỗ trợ

Nếu bạn gặp vấn đề hoặc có câu hỏi:

1. Tạo [Issue](../../issues) trên GitHub
2. Liên hệ qua email: [your-email@example.com]
3. Tham gia [Discussions](../../discussions)

---

⭐ **Nếu project này hữu ích, hãy cho một star!** ⭐

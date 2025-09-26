# Clean Architecture .NET 9 Template

🚀 **High-performance Clean Architecture template with .NET 9, optimized for speed and memory management**

## 📋 Overview

This is a Clean Architecture template built with .NET 9, featuring performance optimizations and intelligent memory management. The template provides a clean, scalable, and maintainable architecture.

---

# Clean Architecture .NET 9 Template

🚀 **Template ứng dụng Clean Architecture với .NET 9, được tối ưu hóa hiệu suất và quản lý bộ nhớ**

## 📋 Tổng quan

Đây là template ứng dụng Clean Architecture được xây dựng với .NET 9, bao gồm các tính năng tối ưu hóa hiệu suất và quản lý bộ nhớ thông minh. Template này cung cấp một kiến trúc sạch, có thể mở rộng và dễ bảo trì.

## 🏗️ Architecture

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

## ✨ Key Features

### 🎯 Clean Architecture
- **Separation of Concerns**: Clear layer separation
- **Dependency Inversion**: Dependency injection pattern
- **SOLID Principles**: Adherence to SOLID principles
- **Domain-Driven Design**: Domain-centric design

### ⚡ Performance Optimizations
- **Entity Framework Core**: Optimized queries and connection pooling
- **Memory Management**: Automatic garbage collection and memory monitoring
- **Performance Monitoring**: Real-time performance tracking
- **Caching**: Memory cache for better performance

### 🛡️ Enterprise Features
- **CQRS Pattern**: Command Query Responsibility Segregation
- **MediatR**: Mediator pattern for loose coupling
- **FluentValidation**: Robust validation
- **Exception Handling**: Global exception handling
- **API Versioning**: API versioning support
- **Swagger Documentation**: Automatic API documentation

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

## 🚀 Installation

### System Requirements
- **.NET 9 SDK** or newer
- **Visual Studio 2022** or **VS Code**
- **SQLite** (included)

### Step 1: Clone repository
```bash
git clone <repository-url>
cd CleanArchDotNetTemplate
```

### Step 2: Restore dependencies
```bash
dotnet restore
```

### Step 3: Update database
```bash
dotnet ef database update --project src/[Project].Persistence --startup-project src/[Project].API
```

### Step 4: Run application
```bash
dotnet run --project src/[Project].API
```

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

## 🔧 Configuration

### Database Settings
Update connection string in `appsettings.json`:

```json
{
  "DatabaseSettings": {
    "ConnectionString": "Data Source=YourDatabase.db"
  }
}
```

### Performance Settings
Configure performance in `appsettings.json`:

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
The application automatically monitors:
- **Response Time**: Response time for each request
- **Slow Requests**: Alerts for requests slower than 1 second
- **Memory Usage**: Memory usage monitoring
- **GC Statistics**: Garbage collection statistics

### Response Headers
Each response includes:
- `X-Response-Time`: Request processing time (ms)
- `X-Request-ID`: Unique request ID
- `X-Memory-Usage`: Current memory usage (bytes)

### Performance Testing
Run performance test script:

```powershell
# Basic test
.\performance-test.ps1

# Test with multiple requests
.\performance-test.ps1 -RequestCount 1000 -ConcurrentUsers 50
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

## 🛠️ Usage

### API Endpoints

#### Examples API
```http
GET    /api/v1/examples          # Get examples list
GET    /api/v1/examples/{id}     # Get example by ID
POST   /api/v1/examples          # Create new example
PUT    /api/v1/examples/{id}     # Update example
DELETE /api/v1/examples/{id}     # Delete example
```

### Swagger Documentation
Access Swagger UI at: `https://localhost:7001/swagger`

### Example Usage

#### Create new Example
```http
POST /api/v1/examples
Content-Type: application/json

{
  "name": "Example Name",
  "description": "Example Description",
  "status": "Active"
}
```

#### Get Examples list
```http
GET /api/v1/examples?page=1&pageSize=10&sortBy=name&sortDirection=asc
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

## 🏗️ Development

### Adding new Use Case

1. **Create Command/Query** in `[Project].Application/UseCases/V1/`
2. **Create Handler** for Command/Query
3. **Create Endpoint** in `[Project].Presentation/Endpoints/V1/`
4. **Register Endpoint** in `MiddlewareExtensions.cs`

### Adding new Entity

1. **Create Entity** in `[Project].Domain/Entities/`
2. **Create Configuration** in `[Project].Persistence/Configurations/`
3. **Add DbSet** to `AppDbContext`
4. **Create Migration**: `dotnet ef migrations add <MigrationName>`

### Adding Repository

1. **Create Interface** in `[Project].Application/Interfaces/Repositories/`
2. **Implement Repository** in `[Project].Persistence/Repositories/`
3. **Register Service** in `ServiceCollectionExtensions.cs`

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
- Use `AsNoTracking()` for read-only queries
- Implement pagination for large datasets
- Use appropriate indexes
- Avoid N+1 queries

### Memory Management
- Dispose objects properly
- Use `using` statements
- Avoid memory leaks
- Monitor GC statistics

### Caching Strategy
- Cache frequently accessed data
- Implement cache invalidation
- Use appropriate cache expiration
- Monitor cache hit rates

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

## 📚 References

- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [.NET 9 Documentation](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [MediatR](https://github.com/jbogard/MediatR)
- [FluentValidation](https://fluentvalidation.net/)

## 📚 Tài liệu tham khảo

- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [.NET 9 Documentation](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [MediatR](https://github.com/jbogard/MediatR)
- [FluentValidation](https://fluentvalidation.net/)

## 🤝 Contributing

1. Fork repository
2. Create feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Create Pull Request

## 🤝 Đóng góp

1. Fork repository
2. Tạo feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Tạo Pull Request

## 📄 License

Distributed under the MIT License. See `LICENSE` for more information.

## 📄 License

Distributed under the MIT License. See `LICENSE` for more information.

## 📞 Support

If you encounter issues or have questions:

1. Create [Issue](../../issues) on GitHub
2. Contact via email: [your-email@example.com]
3. Join [Discussions](../../discussions)

## 📞 Hỗ trợ

Nếu bạn gặp vấn đề hoặc có câu hỏi:

1. Tạo [Issue](../../issues) trên GitHub
2. Liên hệ qua email: [your-email@example.com]
3. Tham gia [Discussions](../../discussions)

---

⭐ **If this project is helpful, please give it a star!** ⭐

⭐ **Nếu project này hữu ích, hãy cho một star!** ⭐
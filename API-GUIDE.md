# 📚 Hướng dẫn sử dụng API

## 🌐 Base Information

- **Base URL**: `https://localhost:7001/api/v1`
- **Content-Type**: `application/json`
- **Authentication**: None (for development)

## 📋 API Endpoints

### Examples API

#### 1. Lấy danh sách Examples
```http
GET /api/v1/examples
```

**Query Parameters:**
- `page` (int): Số trang (default: 1)
- `pageSize` (int): Số items per page (default: 10)
- `sortBy` (string): Field để sort (name, createdAt, etc.)
- `sortDirection` (string): asc hoặc desc (default: asc)
- `status` (string): Filter theo status
- `search` (string): Search term

**Example Request:**
```bash
curl -X GET "https://localhost:7001/api/v1/examples?page=1&pageSize=10&sortBy=name&sortDirection=asc"
```

**Example Response:**
```json
{
  "data": [
    {
      "id": "123e4567-e89b-12d3-a456-426614174000",
      "name": "Example 1",
      "description": "Description 1",
      "status": "Active",
      "createdAt": "2024-01-01T00:00:00Z",
      "modifiedAt": "2024-01-01T00:00:00Z"
    }
  ],
  "pagination": {
    "page": 1,
    "pageSize": 10,
    "totalCount": 100,
    "totalPages": 10
  }
}
```

#### 2. Lấy Example theo ID
```http
GET /api/v1/examples/{id}
```

**Example Request:**
```bash
curl -X GET "https://localhost:7001/api/v1/examples/123e4567-e89b-12d3-a456-426614174000"
```

**Example Response:**
```json
{
  "id": "123e4567-e89b-12d3-a456-426614174000",
  "name": "Example 1",
  "description": "Description 1",
  "status": "Active",
  "createdAt": "2024-01-01T00:00:00Z",
  "modifiedAt": "2024-01-01T00:00:00Z"
}
```

#### 3. Tạo Example mới
```http
POST /api/v1/examples
```

**Request Body:**
```json
{
  "name": "New Example",
  "description": "New Description",
  "status": "Active"
}
```

**Example Request:**
```bash
curl -X POST "https://localhost:7001/api/v1/examples" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "New Example",
    "description": "New Description",
    "status": "Active"
  }'
```

**Example Response:**
```json
{
  "id": "123e4567-e89b-12d3-a456-426614174000",
  "name": "New Example",
  "description": "New Description",
  "status": "Active",
  "createdAt": "2024-01-01T00:00:00Z",
  "modifiedAt": "2024-01-01T00:00:00Z"
}
```

#### 4. Cập nhật Example
```http
PUT /api/v1/examples/{id}
```

**Request Body:**
```json
{
  "name": "Updated Example",
  "description": "Updated Description",
  "status": "Inactive"
}
```

**Example Request:**
```bash
curl -X PUT "https://localhost:7001/api/v1/examples/123e4567-e89b-12d3-a456-426614174000" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Updated Example",
    "description": "Updated Description",
    "status": "Inactive"
  }'
```

#### 5. Xóa Example
```http
DELETE /api/v1/examples/{id}
```

**Example Request:**
```bash
curl -X DELETE "https://localhost:7001/api/v1/examples/123e4567-e89b-12d3-a456-426614174000"
```

**Example Response:**
```json
{
  "message": "Example deleted successfully"
}
```

## 🔍 Response Headers

Mỗi response sẽ bao gồm các headers sau:

```
X-Response-Time: 45ms
X-Request-ID: 12345678-1234-1234-1234-123456789012
X-Memory-Usage: 52428800
```

## 📊 Status Codes

| Code | Description |
|------|-------------|
| 200 | OK - Request thành công |
| 201 | Created - Resource được tạo thành công |
| 400 | Bad Request - Request không hợp lệ |
| 404 | Not Found - Resource không tồn tại |
| 422 | Unprocessable Entity - Validation error |
| 500 | Internal Server Error - Lỗi server |

## 🚨 Error Responses

### Validation Error (422)
```json
{
  "isSuccess": false,
  "isFailure": true,
  "errors": [
    {
      "code": "VALIDATION_ERROR",
      "message": "Name is required"
    }
  ]
}
```

### Not Found Error (404)
```json
{
  "isSuccess": false,
  "isFailure": true,
  "errors": [
    {
      "code": "NOT_FOUND",
      "message": "Example not found"
    }
  ]
}
```

### Server Error (500)
```json
{
  "isSuccess": false,
  "isFailure": true,
  "errors": [
    {
      "code": "INTERNAL_ERROR",
      "message": "An error occurred while processing your request"
    }
  ]
}
```

## 🧪 Testing với PowerShell

### Test cơ bản
```powershell
# Lấy danh sách examples
$response = Invoke-RestMethod -Uri "https://localhost:7001/api/v1/examples" -Method GET
$response | ConvertTo-Json

# Tạo example mới
$body = @{
    name = "Test Example"
    description = "Test Description"
    status = "Active"
} | ConvertTo-Json

$response = Invoke-RestMethod -Uri "https://localhost:7001/api/v1/examples" -Method POST -Body $body -ContentType "application/json"
$response | ConvertTo-Json
```

### Performance Test
```powershell
# Chạy performance test script
.\performance-test.ps1 -RequestCount 100 -ConcurrentUsers 10

# Test với specific endpoint
.\performance-test.ps1 -BaseUrl "https://localhost:7001" -RequestCount 50
```

## 🔧 Swagger UI

Truy cập Swagger UI để test API trực tiếp:
- **URL**: `https://localhost:7001/swagger`
- **Features**: 
  - Interactive API testing
  - Request/Response examples
  - Schema documentation
  - Try it out functionality

## 📈 Performance Monitoring

### Response Time Monitoring
```bash
# Kiểm tra response time
curl -w "@curl-format.txt" -o /dev/null -s "https://localhost:7001/api/v1/examples"
```

Tạo file `curl-format.txt`:
```
     time_namelookup:  %{time_namelookup}\n
        time_connect:  %{time_connect}\n
     time_appconnect:  %{time_appconnect}\n
    time_pretransfer:  %{time_pretransfer}\n
       time_redirect:  %{time_redirect}\n
  time_starttransfer:  %{time_starttransfer}\n
                     ----------\n
          time_total:  %{time_total}\n
```

### Memory Usage Monitoring
```bash
# Kiểm tra memory usage từ response headers
curl -I "https://localhost:7001/api/v1/examples" | grep "X-Memory-Usage"
```

## 🛠️ Development Tools

### Postman Collection
Import Postman collection để test API:
```json
{
  "info": {
    "name": "Clean Architecture API",
    "schema": "https://schema.getpostman.com/json/collection/v2.1.0/collection.json"
  },
  "item": [
    {
      "name": "Get Examples",
      "request": {
        "method": "GET",
        "header": [],
        "url": {
          "raw": "{{baseUrl}}/api/v1/examples",
          "host": ["{{baseUrl}}"],
          "path": ["api", "v1", "examples"]
        }
      }
    }
  ]
}
```

### VS Code REST Client
Tạo file `api-test.http`:
```http
### Get Examples
GET https://localhost:7001/api/v1/examples

### Create Example
POST https://localhost:7001/api/v1/examples
Content-Type: application/json

{
  "name": "Test Example",
  "description": "Test Description",
  "status": "Active"
}
```

## 🔒 Security Best Practices

### HTTPS Only
```bash
# Luôn sử dụng HTTPS
curl -k https://localhost:7001/api/v1/examples
```

### Request Headers
```bash
# Thêm security headers
curl -H "X-Request-ID: $(uuidgen)" \
     -H "User-Agent: MyApp/1.0" \
     https://localhost:7001/api/v1/examples
```

## 📚 Examples

### Complete CRUD Example
```bash
# 1. Tạo example
POST_RESPONSE=$(curl -s -X POST "https://localhost:7001/api/v1/examples" \
  -H "Content-Type: application/json" \
  -d '{"name": "Test Example", "description": "Test Description", "status": "Active"}')

# 2. Lấy ID từ response
ID=$(echo $POST_RESPONSE | jq -r '.id')

# 3. Lấy example theo ID
curl -s "https://localhost:7001/api/v1/examples/$ID"

# 4. Cập nhật example
curl -s -X PUT "https://localhost:7001/api/v1/examples/$ID" \
  -H "Content-Type: application/json" \
  -d '{"name": "Updated Example", "description": "Updated Description", "status": "Inactive"}'

# 5. Xóa example
curl -s -X DELETE "https://localhost:7001/api/v1/examples/$ID"
```

---

💡 **Tip**: Sử dụng Swagger UI để test API một cách trực quan và dễ dàng!

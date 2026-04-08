# 🌾 AgricultureAPI

A comprehensive REST API for agricultural data analysis built with **.NET 10**, featuring JWT authentication, MongoDB database, and advanced user management.

## 📋 Table of Contents

- [Features](#features)
- [Technology Stack](#technology-stack)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Configuration](#configuration)
- [Project Structure](#project-structure)
- [API Endpoints](#api-endpoints)
- [Authentication](#authentication)
- [Contributing](#contributing)

## ✨ Features

- ✅ **JWT Authentication** - Secure token-based authentication with refresh tokens
- ✅ **User Management** - Complete user registration, login, and profile management
- ✅ **MongoDB Integration** - NoSQL database for flexible data storage
- ✅ **Analysis History** - Track and retrieve agricultural analysis records
- ✅ **Swagger Documentation** - Interactive API documentation
- ✅ **Error Handling** - Centralized error handling middleware
- ✅ **CORS Support** - Cross-origin resource sharing configured
- ✅ **Logging** - Serilog integration for comprehensive logging
- ✅ **Password Security** - BCrypt.Net for secure password hashing

## 🛠 Technology Stack

| Component | Technology |
|-----------|-----------|
| **Framework** | .NET 10 |
| **API** | ASP.NET Core Web API |
| **Database** | MongoDB |
| **Authentication** | JWT (JSON Web Tokens) |
| **Validation** | FluentValidation |
| **Object Mapping** | AutoMapper |
| **API Documentation** | Swagger/OpenAPI |
| **Logging** | Serilog |
| **Password Hashing** | BCrypt.Net-Next |

## 📦 Prerequisites

- **.NET 10 SDK** or higher
- **MongoDB Atlas** account (or local MongoDB instance)
- **Visual Studio 2022+** or Visual Studio Code
- **Git**

## 🚀 Installation

### 1. Clone the repository
```bash
git clone https://github.com/Nouma11/AgricultureAPI.git
cd AgricultureAPI
```

### 2. Restore NuGet packages
```bash
dotnet restore
```

### 3. Build the solution
```bash
dotnet build
```

## ⚙️ Configuration

### Step 1: Create appsettings.json

Copy the example configuration:
```bash
cp AgricultureAPI.API/appsettings.example.json AgricultureAPI.API/appsettings.json
```

### Step 2: Update appsettings.json with your credentials

Edit `AgricultureAPI.API/appsettings.json`:

```json
{
  "MongoDB": {
    "ConnectionString": "mongodb+srv://your_username:your_password@your_cluster.mongodb.net/?appName=your_app",
    "DatabaseName": "agriculture_db"
  },
  "JwtSettings": {
    "SecretKey": "your-super-secret-key-32-chars-minimum-length!!",
    "Issuer": "AgricultureAPI",
    "Audience": "AgricultureClient",
    "ExpiryMinutes": "15",
    "RefreshTokenExpiryDays": "7"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

**⚠️ IMPORTANT**: The `appsettings.json` file is gitignored to protect your sensitive credentials.

### Step 3: Run the application

```bash
dotnet run --project AgricultureAPI.API
```

The API will be available at: **http://localhost:5059**

## 📁 Project Structure

```
AgricultureAPI/
│
├── AgricultureAPI.API/
│   ├── Controllers/              # API endpoint controllers
│   ├── Middleware/               # Custom middleware (error handling)
│   ├── Program.cs                # API configuration & DI setup
│   ├── appsettings.json          # ⚠️ DO NOT COMMIT - contains secrets
│   └── appsettings.example.json  # ✅ Configuration template
│
├── AgricultureAPI.Application/
│   ├── Services/                 # Business logic implementation
│   ├── Interfaces/               # Service contracts
│   ├── DTOs/                     # Data Transfer Objects
│   └── AutoMapper/               # Mapping profiles
│
├── AgricultureAPI.Domain/
│   └── Entities/                 # Core business entities
│       ├── User.cs
│       ├── RefreshToken.cs
│       └── AnalysisHistory.cs
│
├── AgricultureAPI.Infrastructure/
│   ├── MongoDB/                  # MongoDB implementation
│   ├── Repositories/             # Data access layer
│   └── Settings/                 # Configuration classes
│
└── README.md                     # This file
```

## 🔌 API Endpoints

### 🔐 Authentication
```
POST   /api/auth/register           # Register new user
POST   /api/auth/signin             # Login user
POST   /api/auth/refresh-token      # Refresh JWT token
```

### 👤 Users
```
GET    /api/users/{id}              # Get user profile
PUT    /api/users/{id}              # Update user profile
DELETE /api/users/{id}              # Delete user account
```

### 📊 History
```
GET    /api/history                 # Get analysis history (paginated)
POST   /api/history                 # Create analysis record
GET    /api/history/{id}            # Get specific history record
DELETE /api/history/{id}            # Delete history record
```

## 🔐 Authentication Flow

### 1. Register
```bash
POST /api/auth/register
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john@example.com",
  "password": "SecurePassword123!"
}
```

### 2. Sign In
```bash
POST /api/auth/signin
Content-Type: application/json

{
  "email": "john@example.com",
  "password": "SecurePassword123!"
}

Response:
{
  "accessToken": "eyJhbGc...",
  "refreshToken": "eyJhbGc...",
  "expiresIn": 900
}
```

### 3. Use Access Token
```bash
Authorization: Bearer eyJhbGc...
```

### 4. Refresh Token (when access token expires)
```bash
POST /api/auth/refresh-token
Content-Type: application/json

{
  "refreshToken": "eyJhbGc..."
}
```

## 📚 Swagger Documentation

Once the application is running, access the interactive Swagger UI at:
```
http://localhost:5059/swagger
```

## 🔒 Security Features

- ✅ JWT token-based authentication with expiration
- ✅ Refresh token rotation for enhanced security
- ✅ Password hashing with BCrypt
- ✅ CORS configuration for specific origins
- ✅ Sensitive configuration files excluded from version control
- ✅ Input validation with FluentValidation
- ✅ Centralized error handling middleware
- ✅ HTTP HTTPS redirection in production

## 📝 Development Commands

### Restore dependencies
```bash
dotnet restore
```

### Build solution
```bash
dotnet build
```

### Run in development
```bash
dotnet run --project AgricultureAPI.API
```

### Publish for production
```bash
dotnet publish -c Release -o ./publish
```

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. **Fork** the repository
2. **Create** a feature branch (`git checkout -b feature/amazing-feature`)
3. **Commit** your changes (`git commit -m 'Add amazing feature'`)
4. **Push** to the branch (`git push origin feature/amazing-feature`)
5. **Open** a Pull Request

## 📄 License

This project is licensed under the MIT License.

## 📞 Support

For issues, questions, or suggestions, please [create an issue](https://github.com/Nouma11/AgricultureAPI/issues) on GitHub.

## 🔄 Latest Updates (v1.0.0)

- ✅ JWT Authentication with refresh tokens
- ✅ User management system
- ✅ MongoDB integration
- ✅ Analysis history tracking
- ✅ Swagger API documentation
- ✅ Security vulnerability fixes & package updates
- ✅ Sensitive configuration files properly gitignored

---

**Built with ❤️ using .NET 10**

*For more information, visit the [GitHub Repository](https://github.com/Nouma11/AgricultureAPI)*
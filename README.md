# 📚 CollegeSystem – College Management System API
*An API built using Clean Architecture principles for managing college-related data such as Departments and Students. This project leverages ASP.NET Core 8, Entity Framework Core, and follows best practices like Separation of Concerns and Dependency Inversion.*

## 🧱  Project Structure
 The solution is organized into distinct layers to enforce clean separation and maintainability:


```
CollegeSystem2/
├── Domain/                      # Entities and core interfaces
├── Application/                 # Business logic, DTOs, and service interfaces
├── Infrastructure/              # Data access layer with EF Core implementation
├── CollegeSystem2/              # API layer containing Controllers and Middleware
│   ├── Controllers/             # RESTful API endpoints for Departments and Students
│   ├── Middleware/              # Custom error handling middleware
│   └── Program.cs               # Application startup and DI configuration
└── CollegeSystem2.Tests/        # Unit and integration tests for the application
```
## ✨ Key Principles
- **Separation of Concerns (SoC):** Clear division of responsibilities between layers.

- **Dependency Inversion:** High-level modules do not depend on low-level modules.

- **Testability:** Designed to support unit and integration testing.

- **Loose Coupling:** Ensures that changes in one layer minimally affect others.

---

## 🔧 Technologies Used

**-** **Backend Framework: ASP.NET Core 8**

**-** **Database: SQL Server**

**-** **ORM: Entity Framework Core**

**-** **API Documentation: Swagger**

**-** **Logging: Built-in .NET Core logging**

**-** **Testing: xUnit, Moq**

**-** **Dependency Injection: .NET Core DI Container**

---

## 🚀 Getting Started

 **✅ Prerequisites**

**-** **.NET 8 SDK**

**-** **Visual Studio 2022 or VS Code**

**-** **SQL Server (or Docker for SQL Server)**

---

## 📥 Installation

 **1. Clone the repository:**

```
git clone https://github.com/MISBAH-UL-HAQ/Layered_WebApi_CollegeSystem2.git

cd Layered_WebApi_CollegeSystem2
```


 **2. Set up the database:**

- **Update the connection string in `CollegeSystem2/appsettings.json` (e.g., change the server name or database as needed).**

- **Open the Package Manager Console in Visual Studio and run:**

```
add-migration "InitialCreate"

update-database
```

---

## ▶️ Running the Application

- **From the solution directory:**

```
cd CollegeSystem2

dotnet run
```

**The API should now be running on:**

- **[https://localhost:7220](https://localhost:7220)**
#### OR
- **[http://localhost:5222](http://localhost:5222)**

**-** **Swagger UI is available for testing the endpoints.**

---

## ✅ Testing

 **To run the tests:**

```
cd CollegeSystem2.Tests

dotnet test
```

---
## 📡 API Endpoints

### 🔷 Department Management

| Method | Endpoint                      | Description                  |
|--------|-------------------------------|------------------------------|
| GET    | `/api/departments`            | Get all departments          |
| GET    | `/api/departments/{id}`       | Get department by ID         |
| POST   | `/api/departments`            | Create new department        |
| PUT    | `/api/departments/{id}`       | Update existing department   |
| DELETE | `/api/departments/{id}`       | Delete department            |
---

### 🔷 Student Management


| Method | Endpoint                      | Description                  |
|--------|-------------------------------|------------------------------|
| GET    | `/api/students`            | Get all students         |
| GET    | `/api/students/{id}`       | Get student by ID         |
| POST   | `/api/students`            | Create new student        |
| PUT    | `/api/students/{id}`       | Update existing student   |
| DELETE | `/api/students/{id}`       | Delete student           |

---
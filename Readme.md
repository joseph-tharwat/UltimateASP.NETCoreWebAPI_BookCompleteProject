# Ultimate ASP.NET Core Web API Book Project

A comprehensive, end-to-end implementation following the "Ultimate ASP.NET Core Web API" book. This repo features a full-stack Web API project including presentation, services, repositories, logging, and shared components.

It is about a companies and employees insed each company Performing CRUD operation on them with different techniques.

## 📚 About
It demonstrates best practices across:
- Onion architecture  
- Dependency Injection  
- Logging  
- Generic repository & unit-of-work  
- Proper separation of concerns 
- filtering and searching 

## 🧱 Project Structure
/

├── CompanyEmployees.Presentation # API endpoints / controllers

├── Service # Service(Application) layer

├── Service.Contract # Services Interfaces

├── Repository # Data access layer

├── Entities # Domain models / EF Core entities, Exceptions

├── Contracts # repos Interfaces, Logger Interface

├── LoggerService

├── Shared # DTOs, Request Parameters classes

├──CompanyEmployees # JWT controller, Extensions, Formatter, Mapper, Migrations, Program.cs

### Prerequisites
- [.NET 8]
- SQL Server

### Setup Steps
1. Clone the repo
2. Adjust your connection string in CompanyEmployees.Presentation/appsettings.json.
3. Run migrations
4. Run the application

### Features
Onion Architecture – Controllers → Services → Repos → Data

Generic Repository Pattern – Reusable data access

Dependency Injection – Built-in DI throughout the app

Logging – Via LoggerService, easy to customize

Entities/DTOs – Entity models and Data Transfer Objects

Default Swagger – Auto-generated API documentation

Error Handling – Centralized error workflow


#### Any comments are welcome!



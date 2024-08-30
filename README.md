# HealthClinic
ASP.NET Core Web App MVC Project
# Training Project: MvcMovies

## Project Overview

This project is a training application developed using ASP.NET Core MVC. It is built on Ubuntu and uses Visual Studio Code as the development environment. The project utilizes .NET CLI commands for creating and managing the application.

## Technology Stack

- **Framework:** ASP.NET Core MVC
- **Database:** SQLite(Development), MySQL(Production)
- **ORM:** Entity Framework Core
- **Development Tools:** Visual Studio Code, .NET CLI
- **Web Server:** Kestrel

## Features

- **CRUD Operations:** Implemented for managing resources.
- **Database Integration:** Uses SQL Server with Entity Framework Core for database management.
- **Basic Data Validation:** Includes fundamental validation and error handling mechanisms.
- **Seed data** Implement seeding to populate the database with initial data.
- **Search Functionality:** Allows users to search through data.

## Steps Taken to Build and Create the Project

1. **Create the Project:**
   ```
   dotnet new mvc -o MvcMovie
   code -r MvcMovie
   ```

2. **Trust the HTTPS Development Certificate**
Trust the development certificate for HTTPS, then update appsettings.json to configure Kestrel with your certificate details and HTTPS URL (https://localhost:5001). Use an environment variable for the certificate password.

3. **Add Required NuGet Packages:**
    ```
    dotnet tool uninstall --global dotnet-aspnet-codegenerator
    dotnet tool install --global dotnet-aspnet-codegenerator
    dotnet tool uninstall --global dotnet-ef
    dotnet tool install --global dotnet-ef
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.EntityFrameworkCore.SQLite
    dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Tools
    dotnet add package DotNetEnv
    ```

4. **Use Scaffolding to Generate Movie Pages:**
   ```
    dotnet aspnet-codegenerator controller -name MoviesController -m Movie -dc MvcMovie.Data.MvcMovieContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite
   ```
*Scaffolding Generates:*
- MoviesController in Controllers/MoviesController.cs
- Razor view files for Create, Delete, Details, Edit, and Index pages in Views/Movies/*.cshtml
- A database context class in Data/MvcMovieContext.cs

*Scaffolding Updates:*
- Registers the database context in Program.cs
- Adds a database connection string to appsettings.json

5. **Use EF Core Migrations to Create the Database:**
  ```
   dotnet ef migrations add InitialCreate
   dotnet ef database update
  ```

## Installation Instructions

1. **Clone the Repository:**
  ```
  git clone https://github.com/ViktoriyaHor/MvcMovie.git
  ```
2. **Navigate to the Project Directory:**
  ```
  cd your-repo
  ```
3. **Create .env file using .env example:**
   ```
   cp .env.example .env
   ```
4. **Restore Dependencies:**
  ```
  dotnet restore
  ```
5. **Apply Database Migrations:**
  ```
  dotnet ef database update
  ```
6. **Run the Application:**
  ```
  dotnet run
  ```
in Visual Studio Code, use Ctrl+F5.

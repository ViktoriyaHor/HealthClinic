# HealthClinic
ASP.NET Core Web App MVC Project

*Description:* "HealthClinic" is a medical information system designed for clinics to manage medical data and ensure quality patient care. 

*Home Page* - a main page of the application provides an introduction to the clinic, including essential information about and contact details.

*Login/Logout* 
The application offers secure user authentication, allowing users to log in with their email and password, with options to remember login details, and to securely log out.

*Admin Panel Pages*  contains
- list of users with the ability to create/edit/delete 
- list of roles with the ability to create/edit/delete and assign to user

## Technology Stack

- **Framework:** ASP.NET Core MVC
- **Database:** SQL Server (via Entity Framework Core)
- **ORM:** Entity Framework Core
- **Development Tools:** Visual Studio Code, .NET CLI
- **Front-End Framework:** Bootstrap
- **Authentication and Authorization:** ASP.NET Identity
- **Version Control:** Git

## Features

- **CRUD Operations:** Implemented for managing resources.
- **Database Integration:** Uses SQL Server with Entity Framework Core for database management.
- **Basic Data Validation:** Includes fundamental validation and error handling mechanisms.
- ****


## Steps Taken to Build and Create the Project

1. **Create the Project:**
   ```
   dotnet new mvc -o HealthClinic
   code -r HealthClinic
   ```

2. **Trust the HTTPS Development Certificate**
Trust the development certificate for HTTPS, then update appsettings.json to configure Kestrel with your certificate details and HTTPS URL (https://localhost:5001). Use an environment variable for the certificate password.

3. **Add Required NuGet Packages:**
    ```
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.SQLServer
    dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
    dotnet add package DotNetEnv
    ```

4. **Use EF Core Migrations to Create the Database:**
  ```
   dotnet ef migrations add InitialCreate
   dotnet ef database update
  ```

## Installation Instructions

1. **Clone the Repository:**
   ```
   git clone https://github.com/ViktoriyaHor/HealthClinic.git
   ```
2. **Navigate to the Project Directory:**
   ```
   cd HealthClinic
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
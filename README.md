## Developer Test
# This repository contains a full-stack application with:

Backend: ASP.NET Core for managing API and database.
Frontend: Angular for user interface.

## Prerequisites
# Global Requirements
.NET Core SDK (version 6 or higher) - Install .NET SDK
SQL Server (for database)
Node.js (version 14 or higher) - Install Node.js
Angular CLI - Install globally via npm install -g @angular/cli

## Setup Instructions
# 1. Clone the Repository
git clone https://github.com/maddyrahul/Developer-Test.git
cd Developer-Test

# Backend Setup (ASP.NET Core)
# 2. Navigate to the Backend Folder
cd DeveloperTest

# 3. Install Backend Dependencies
dotnet restore

# 4. Update the Database Connection String
In the DeveloperTest/appsettings.json, update the connection string to match your SQL Server instance:
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server;Database=SchoolDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}

# 5. Apply Database Migrations
Run the following command to apply the migrations and set up your database schema:
dotnet ef database update

# 6. Run the Backend
Run the backend server using the command below:
dotnet run
The backend will be available at https://localhost:7273.

## Frontend Setup (Angular)
# 7. Navigate to the Frontend Folder
cd ../UI

# 8. Install Frontend Dependencies
Run the following command to install all required dependencies:
npm install

## 9. Run the Frontend
Run the Angular application using the command below:
ng serve
The frontend will be available at http://localhost:4200.



   

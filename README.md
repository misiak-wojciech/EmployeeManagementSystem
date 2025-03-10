# EmployeeManagementSystem

This is a web application built using **ASP.NET Core 8** with **Entity Framework Core** and **SQL Server Express**. It allows management of employees, their salaries, leaves, departments, and positions. This application uses Bootstrap for the UI and is designed to be simple yet effective for managing employee-related data.

## Technologies

- **ASP.NET Core 8** 
- **Entity Framework Core** 
- **SQL Server Express** 
- **Bootstrap** 


## Prerequisites

Before you start, make sure you have the following installed on your system:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet) (or newer)
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/) or a suitable IDE

## Setup

Follow these steps to set up and run the project locally:

### 1. Clone the repository

```bash
git clone https://github.com/misiak-wojciech/EmployeeManagementSystem.git  
```
### 2. Restore dependencies
Restore the project dependencies using the following command:
```
dotnet restore
```
### 3. Add migrations
Before updating the database, we need to add migrations based on the current model:
```
dotnet ef migrations add InitialCreate
```
This will generate the migration files required to set up the database schema.

### 4. Update the database
Once the migration is added, update the database with:
```
dotnet ef database update
```
This command will apply all the migrations and set up the database for the application.

### 5. Run the application
Now, you are ready to run the application:
```
dotnet run
```
This will start the application, and you can access it in your browser at localhost.

## Database Configuration
If you are using SQL Server Express, make sure to have a connection string in the appsettings.json file. Since you mentioned that appsettings.json is not included in the repository, you will need to manually configure it. 

<p align="center">

 ## 💻 Project

API REST for school management.

The project was developed as the final project of the first module of the Professionalizing course in Full Stack development.
</p>

## Technologies

List of technologies used in the project:

- [C#](https://learn.microsoft.com/pt-br/dotnet/csharp/)
- [ASP.NET Core](https://learn.microsoft.com/pt-br/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0)
- [EntityFrameworkCore](https://learn.microsoft.com/en-us/ef/)
- [Fluent API](https://learn.microsoft.com/pt-br/ef/ef6/modeling/code-first/fluent/types-and-properties)
- [Fluent Validation](https://docs.fluentvalidation.net/en/latest/aspnet.html)
* [MVC Pattern](https://dotnet.microsoft.com/en-us/apps/aspnet/mvc)

## Abstraction methodology applied for development:

1. Package installation
2. Base Class declaration
3. Models creation
4. Context creation
 4.1. Dependency injection
 4.2. Connection String configuration
5. Fluent API configuration
 5.1. Initial data insert
6. Migrations perform
7. Data Transfer Objects creation
8. Interfaces creation
 8.1. Repositories creation
 8.2. Controllers creation
9. Fluent Validation configuration
 9.1. Dependency injection
10. Database update
11. Commit

## Running the project

1. Clone the repository:

```bash
$ git clone https://github.com/alexandrenolla/API-REST
$ cd API-REST
```


2. Change the path at the Connection String in the appsettings.Development.json file to the path of your local folder

```
 "ConnectionStrings": {
    "LabSchoolContext" : "Data Source=/yourlocalpath/[alexandre]labschoolbd.db;"
  } 
```

3. Install the following packages by running the commands:


```
 dotnet add package Microsoft.EntityFrameworkCore  

 dotnet add package Microsoft.EntityFrameworkCore.Tools 
 
 dotnet add package Microsoft.EntityFrameworkCore.Design

 dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

4. Run the command:

```
 dotnet run
```

The API will be available at http://localhost:5127/swagger.

## Instructions

1. dotnet new webapi -o VehiculosApi
2. dotnet add package Microsoft.EntityFrameworkCore.SqlServer
3. dotnet add package Microsoft.EntityFrameworkCore.InMemory
4. dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
5. dotnet add package System.IdentityModel.Tokens.Jwt
6. dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
7. dotnet add package Microsoft.EntityFrameworkCore.Design
8. Open project in vs code
9. dotnet run
10. See it running here: https://localhost:5001/WeatherForecast
11. Create Models directory
12. Create Model Class Vehicle
13. Create database context class
14. Register the database context in Startup.cs file
15. dotnet tool install --global dotnet-aspnet-codegenerator
16. dotnet aspnet-codegenerator controller -name VehiclesController -async -api -m Vehicle -dc DataBaseContext -outDir Controllers
17. Read reference here: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio-code

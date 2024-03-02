#Web API for the CDN - Complete Developer Network User Management System

- Using ASP.NET Core, MSSQL with Microsoft SQL Server Management Studio (SSMS), Web API (Swagger)
- To build a list of freelancers.

## Table of Contents

-[Introduction](#Introduction)
-[Technologies Used](#Technologies-Used)
-[Tools Used](#Tools-Used)
-[Functions in Web API](#Functions-in-Web-API)
-[To Get Started](#To-Get-Started)
-[Web API Endpoint](#Web-API-Endpoint)

## Introduction
CDN - Complete Developer Network User Management System is used to build a list of freelancers. 
Such that they could have a directory of contact get people for their job.

## Technologies Used
- ASP.NET Core Web API
- .NET 6.0 Framework
- MSSQL (RDBMS)

## Tools Used
- Visual Studio 2022
- Microsoft SQL Server Management Studio(SSMS)

## Functions in Web API
- Get a list of users.
- Get a single user using ID.
- Create a new user.
- Update a user details.
- Delete a user.

## To Get Started
Please follow the steps below to run the project in the localhost:
1. Install Visual Studio 2022 and Microsoft SSMS if they are not already installed.
2. Clone the CDN_Freelancers repository in your computer/laptop.
3. Open the project in Visual Studio 2022.
4. Open 'appsetting.json' file, make sure the server name in the 'ConnectionStrings'matches the server name in your SSMS configuration.
5. Open 'Tools' > 'NuGet Package Manager' > 'Package Manager Console'.
6. Write the command 'Add-migration Initial' to add migration.
7. Write the command 'Update-database' to update the database in SSMS.
8. In the Solution Explorer, right click the 'Solution CDN_Web_API' and click 'Properties'.
9. In the Startup Project, click the 'Multiple startup projects'.
10. Choose 'CDN_MVC' and 'CDN_Web_API', then click 'Start' for the Action.
11. Click 'OK' button to ensure the Web API and the Web App can be run simultaneously.
12. Run the project.

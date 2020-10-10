# Shopy
Sample Inventory Management Demo for trying .Net Core Web Api with Blazor as frontend

This is the stable version of a simple application with Product CRUD operations

1) Instructions for running the project.

The app is stable but a bit slow in responding so please be patient. 

-> Setpup the database first with the given SQL Script. First manually create the databsse 'ShopBridge' and then run the given SQL Script.
It will create the required tables and a default user(User creation is not in scope but created for scalability).
InventoryLog table related work is also out of scope and kept only for future enhancements.

-> Blazor and Asp.Core environment with framework Net Core 3.1 are required.
-> Once you download the solution and open it using suitable Visual Studio (project developed using Visual Studio 2019), you need to set up the solution to start multiple projects at once.
 Reference link for the process.
 https://improveandrepeat.com/2019/01/starting-multiple-projects-at-once-in-visual-studio/
 
 Projects required to startup:
 
 ShopBridge.Api
 ShopBridge.Web

-> Setup the connection string of the database created above in ShoBridge.Api project's appsettings.json file in section 
ConnectionStrings -> ShopBridgeDatabase.
 
-> Then you need to make sure appropriate paths are configured for project to run.
You should copy the path mentioned in ShopBridge.Api (using Project -> Properties -> Debug (See path mentioned with Enable SSL checkbox)).
Paste this path in ShopBridge.Web project's appsettings.json file in the section -> ApiConfig -> BaseUrl.

->  That's it and the project should run successfully now. Please use valid values for testing as validations are pending. 
 
2) Work/Technologies related stuff:

-> Backend : .Net Core 3.1 Web Api (file upload working in api(backend) using postman)
-> Frontend : Blazor with .Net Core 3.1 (file upload pending)
-> Entity Framework
-> Repository Pattern  

Working functionality:
-> Product CRUD with inventory(quantity) management 
-> Simple UI design
-> Center aligned content
-> Asynchronous approach for coding
 
Pending functionality
-> Unit test cases (was planning to use Moq along with MSTest or NUnit but spared more time in file upload)
-> File Upload (working in backend but not in front end)
-> Validations

Pending Enhancements
-> Log Inventory/Qunatity every time inventory is added or updated and store it in InventoryLog Table

3) Time spent in development

FrontEnd - 2 days
Backend - 3 days
Integration - 2 days
DB Design - 1 day
UI Design  - 0.5 day(s)
Unit Testing - 0 days (pending)

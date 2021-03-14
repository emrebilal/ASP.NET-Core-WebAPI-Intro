# ASP.NET Core Web API
I have created a simple CRUD application and defined routes for all the four types of HTTP methods (GET, POST, PUT, DELETE) with API paths.  
In this app, I have not used any database. All the operations are in-memory. I saved them to a JSON file so that data would not be lost after the application was closed.

Creates the following API:  
|API|Description|Request body|Response body|
|-|-|-|-|
|**GET** /api/products|Get all products|None|Array of products|
|**GET** /api/products/{id}|Get an product by ID|None|Product|
|**POST** /api/products|Add a new product|Product|Product|
|**PUT** /api/products/{id}|Update an existing product|Product|None|
|**DELETE** /api/products/{id}|Delete an product|None|None|

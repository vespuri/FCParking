# FCParking

Demonstration of a REST API simulating basic parking control.

## Project Objective

This project aims to demonstrate and exemplify a REST API in .NET Core.

### Technologies Used

- .NET CORE 3.1
- SQL SERVER
- REDIS for token storage in Cache
- JWT Authentication
- XUnit for Unit Testing (2 tests for demonstration)
- Moq for object mocking
- Serilog for application logging
- Swashbuckle Swagger for API exposure

### Running the Project

First step is to configure the connection strings in the `appsettings.json` file. I used one database for the application and another for authentication.

```
Connection Strings:
BaseIdentity: String for Authentication
App: String for the Application
ConexaoRedis: String for token storage in Cache
```  

      
```
Example: I used the local SQL Server database  
ConnectionStrings: {
    "BaseIdentity": "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=IdentityLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",  
    "App": "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=AppDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
    "ConexaoRedis": "localhost,port: 6379,password=Redis2020!"
  },

```

Since I used Redis, you need to point the connection string to a Redis server. If you want to run the server locally, follow the instructions below.

### Configuring REDIS

Step by Step:

1. **Download Redis**

   [Redis Download Link](https://github.com/microsoftarchive/redis/releases/tag/win-3.2.100)

2. **Unzip the File**

   If you download the zip file, unzip it to `C:\Redis`.

3. **Start redis-server**

   A command prompt window will open with the message "The server is now ready to accept connections on port 6379."

**Tip:** If the command doesn't work in the command prompt, you need to add a value to the "Path" Environment Variable with the path to the files "C:\Redis".


### After this, the project should run without problems.



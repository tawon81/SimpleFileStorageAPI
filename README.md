# SimpleFileStorageApi
Appropriately named, this repository contains a .NET 6.0 based Web API project that provides CRUD operations for binary files. The file's name, contents, and version are stored in a SQLLite Database. Files contain a version property that is set when file is added and incremented when a file with same name is uploaded or if content on an existing file is updated. The API provides Open API Swagger documentation which provides documentation of the endpoints and an interface through which the API can be used.

Tech Stack Utilized:

.Net 6 Core

Entity Framework

SQLLite DB

# Endpoints and Payloads
POST File/Upload/ - Adds a file or revision to db utilizes a IFormFile object to pass file information from HTTP request. Uploading a modified copy of an exisiting file will save the file with an automatically incremented version. Returns a Status200OK and basic file information including ID on success, and Status400BadRequest if request fails

GET File/GetFile/{id} - Returns file from the db based on id. Returns a Status200OK with file information on success, and Status400BadRequest if request fails.

GET File/GetFiles/ - Returns a list of all files and associated info in the db. No parameters required. Returns a Status200OK on success and Status400BadRequest if request fails

GET File/GetFilesByName/{FileName} - Returns a list of all files and associated info in the db. Takes a string FileName parameter and returns all files that have a matching FileName in the db. Helpful in identifying multiple versions, and max version Id.  Returns a Status200OK on success and Status400BadRequest if request fails

PUT /File/Update/{id} - Updates an existing file based on id and IFormFile object. If FileName exists and file content is modified version will be incremented. Returns a Status200OK on success and Status400BadRequest if request fails.

DELETE /File/Delete/{id} - Deletes a single file from the db based on id. Returns a Status200OK on success and Status400BadRequest if request fails

# Instructions
To utilize the API, you can execute it using Visual Studio. 

You can also do the following if VS is not available:

Clone the Github repo to your local machine.

Ensure that you have .NET 6 SDK installed on your machine. You can download it from the official .NET website.

Open a command prompt or terminal window and navigate to the project folder in the cloned repository.

If you aim to debug/run it locally, make sure to install SQLLite on your machine.

SQLLite database file is stored at the following path:  
C:\TEMP\FileStorage.db

Open the appsettings.json file and verify that the database connection string is pointing to a valid SQLLite instance. You may need to modify this connection string to match your local instance. You can also create a new SQLLite database if you don't have one already.

Finally, run the following command to start the application: dotnet run

# Solution 

SimpleFileStorageApi: .Net 6 Core Web API. Uses FileService to store the files in a SQLLite Database.

Services: Service that contains all business logic for CRUD operations.

Data: Database context.  

SQLLite database file is stored at the following path:  
C:\TEMP\FileStorage.db


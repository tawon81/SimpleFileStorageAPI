# FileRepoServiceApi
Appropriately named, this is a simple file storage API with basic CRUD functionality. Files contain a version property that is set when file is added and incremented when a file with same name is uploaded or if content on an existing file is updated.

Tech Stack Utilized:

.Net 6 Core

Entity Framework

SQLLite DB

# Endpoints and Payloads
POST File/Upload/ - Adds a file or revision to db utilizes a IFormFile object to pass file information from HTTP request. Uploading a modified copy of an exisiting file will save the file with an automatically incremented version. Returns a Status200OK and basic file information including ID on success, and Status400BadRequest if request fails

GET File/GetFile/{id} - Returns file from the db based on id. Returns a Status200OK with file information on success, and Status400BadRequest if request fails.

GET File/GetFiles/ - Returns a list of all files and associated info in the db. No parameters required. Returns a Status200OK on success and Status400BadRequest if request fails

GET File/GetFilesByName/{FileName} - Returns a list of all files and associated info in the db. Takes a string FileName parameter and returns all files that have a matching FileName in the db. Returns a Status200OK on success and Status400BadRequest if request fails

PUT /File/Update/{id} - Updates an existing file based on id and IFormFile object. If FileName exists and file content is modified version will be incremented. Returns a Status200OK on success and Status400BadRequest if request fails.

DELETE /File/Delete/{id} - Deletes a single file from the db based on id. Returns a Status200OK on success and Status400BadRequest if request fails

# Instructions
To utilize the API, you can
execute it using Visual Studio. 

SimpleFileStorageApi: .Net 6 Core Web API. Uses FileService to store the files in a SQLLite Database.
Services: Service that contains all business logic for CRUD operations.
Data: Database context.  

SQLLite database file is stored at the following path:  
C:\TEMP\FileStorage.db


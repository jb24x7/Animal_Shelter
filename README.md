# Animal Shelter Api

#### By James Provance

## Technologies Used

* C#
* .Net 6
* HTML
* JavaScript
* JSON
* SQL
* EFCore
* Identity
* Authentication & Authorization

## Description
This web api was created to be able to add shelters to a database and add animals to each shelter.  Users can also query the database to get shelters by name and location. Users can also query for a random shelter.

## Setup/Installation Requirements

1. Clone this repo.
2. Open your terminal (e.g., Terminal or GitBash) and navigate to this project's production directory named "SheltersLookup".
3. Create a file named ['appsettings.json'] in the production directory (SheltersLookup) and include a new database connection string. The string should be as follows:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306[Or-Your-Desired-Port-Number];database=[DATABASE-NAME-HERE];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];",
  }
}
Create a database name, update username and password to match the username and password of your computer.
4. Enter 'dotnet ef database update' in the terminal inside the production directory (this will create the database schema in MySQL which the application will access later), enter 'dotnet run' or 'dotnet watch run' in the command line to start the project in development mode with a watcher (Optionally, you can run "dotnet build" to compile the app without running it). 
5. First you will need to register a user. Using Postman send a POST request to: http://localhost:5114/api/Account/regsiter. In the body of the request send:
  {
    "userName": "string",
    "password": "string"
  }
6. Once a user is registered they are able to login by sending a POST request to: http://localhost:5114/api/Account/login. In the body of the request send:
  {
    "userName": "string",
    "password": "string"
  }
7. Once you are logged in users can send POST requests to /api/Shelters with the body:
  {  
    "name": "string", (type of shelter such as National or State)
    "name": "string"
  }
8. Users are also able to send a GET request to /api/Shelters to retrieve all shelters in the database.
9. Users can send a GET request with a specific id to get a specific shelter: /api/Shelters/{id}.
10. Users are able to update entries in the database by sending a PUT request to: /api/Shelters{id} with the body:
  {  
    "shelterId": {id},
    "Name": "string",
    "name": "string"
  }
11. Users are also able to delete entries by sending a DELETE request to /ap/Shelters/{id}.
12. Users are able to create animals by sending a POST request to /api/Animals with the body:
  {
    "shelterId": {id},
    "name": "string",
    "userName": "string"
  }
13. Users are also able to see all animals, edit and delete animals by following the same convention for shelters with with the appropriate body.


## Known Bugs
*No known bugs at this time.

## License
MIT

Copyright (c) 4/2/2023 James Provance

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
# BoxOffice
This is a service for Box office to manage movies with authors and producers. This is written using ASP.NET CORE 2.2, EF CORE, Mediatr, Automapper and FluentValidation using Clean Architecture principle. 

## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio Code or 2017](https://www.visualstudio.com/downloads/)
* [.NET Core SDK 2.2](https://www.microsoft.com/net/download/dotnet-core/2.2)

### Setup
Follow these steps to get your development environment set up:

  1. Clone the repository
  2. At the root directory, restore required packages by running:
     ```
     dotnet restore
     ```
  3. Next, build the solution by running:
     ```
     dotnet build
     ```
  4. Add migration within BoxOffice.Persistence by running:
    ```
    dotnet ef migrations add InitialCreate
    ```
  5. Launch [https://localhost:55218/swagger] to see list of API's and schema in swagger.
    

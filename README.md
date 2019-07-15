
## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio Code or 2017](https://www.visualstudio.com/downloads/)
* [.NET Core SDK 2.2](https://www.microsoft.com/net/download/dotnet-core/2.2)

### Setup
Follow these steps to get your development environment set up:

1. Unzip the file SWAPI_StarWarsAPI.zip
2. At the root directory, restore required packages by running:
    ```
    dotnet restore
    ```
3. Next, build the solution by running:
    ```
    dotnet build
    ```
4. Next, launch by running:
    ```
    dotnet run --project "source/SWAPI.Application/SWAPI.Application.csproj"
    ```
5. For run tests:
    ```
    dotnet test "tests/SWAPI.UnitTests/SWAPI.UnitTests.csproj"
    ```
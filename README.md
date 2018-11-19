# SpaceX Launchpad Api

The __SpaceX Launchpad Api__ consumes and makes available data from the [SpaceX REST Api](https://github.com/r-spacex/SpaceX-API/wiki/Launchpad-Info). 

The solution consists of three projects:

* __SpaceX.Api__: An AspNetCore webapi with a controller that makes two endpoints available.
* __SpaceX.Tests__: Unit tests for the api controller methods.
* __LaunchData.Lib__: A class library referenced by the api that is responsible for making calls to the SpaceX REST Api and deserializing the response.

## Problem

The webapi project currently exposes the SpaceX REST Api through a class library. It needs to be designed anticipating that the class library can be replaced by an internal database.

## Solution

The third-party api connects to the main webapi project through the ILaunchDataService interface which is injected as a singleton object at Startup.ConfigureServices. To create an internal data source, ILaunchDataService can be injected with a different service depending on the HostingEnvironment object or a different configuration settings. This would have no impact on the controller methods.

## Setup

1. Download and install the [.NET Core SDK](https://www.microsoft.com/net/download)

1. Clone this repo: `$ git clone [GET REPO URL]`

1. To run the WebApi project: `$ dotnet run --project SpaceXLaunch.Api/SpaceXLaunch.Api.csproj`

1. To run the unit tests: `$ dotnet test SpaceXLaunch.Tests/SpaceXLaunch.Tests.csproj`

## Endpoints

So far, the api consists of two methods.

 * To get all launchpads:
`https://localhost:5001/api/Launches`

 * To get one launchpad by id:
 `https://localhost:5001/api/Launches/{id}`

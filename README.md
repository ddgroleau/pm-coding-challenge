# Organization Summary Service

## What is this?

A .NET 7 Web API consisting of a single endpoint, `/api/organization-summaries`, which combines and summarizes data from three mock endpoints.

## Prerequisites

1. NET 7 SDK installed.
2. (Optional) Docker installed.

## Running the project locally

1. From the root directory, run the following commands:

```
dotnet restore
dotnet run --project WebApi
```

## Running the project with Docker

1. From the root directory, build the docker image:

```
docker build . -t pm-coding-challenge
```

2. Run the docker container on http://localhost:5000:

```
docker run -d -p 5000:80 --name pm-coding-challenge pm-coding-challenge
```

## Making HTTP Requests

1. Make a GET request to the `/api/organization-summaries` endpoint:

```bash
curl http://localhost:5000/api/organization-summaries
```

2. Alternatively, navigate to `http://localhost:5000/swagger/index.html` to send a GET request via the Swagger UI.

## Running the tests

The XUnit test project contains both Unit and Integration tests. Use the command `dotnet test` to run the full test suite.

- Note: I opted to test crucial components rather than attempt 100% test coverage. Business logic is covered by unit tests, and external dependencies and controller routes are covered by integration tests

## Adding Monitoring & Logging

- The API can be monitored by sending a GET request to it's health check endpoint at `/health`.
- Logging sinks can be configured with NuGet packages such as `Serilog`.

# Chono PM - ASP.NET Core Web API

This project provides the backend functionality for the Chono PM application using ASP.NET Core Web API.

## Development server

To run the API locally, follow these steps:

1. Install the [.NET Core SDK](https://dotnet.microsoft.com/download).
2. Clone the repository.
3. Navigate to the `server` directory.
4. Run the command `dotnet run` to start the development server.
5. The API will be hosted at `http://localhost:5000` (or `https://localhost:5001` if HTTPS is enabled).

## Endpoints

The following endpoints are available:

- `GET /api/issue`: Retrieve all issues.
- `GET /api/issue/{id}`: Retrieve a specific issue by ID.
- `POST /api/issue`: Create a new issue.
- `PUT /api/issue/{id}`: Update an existing issue.
- `DELETE /api/issue/{id}`: Delete a issue.

## Further help

To get more help with ASP.NET Core Web API, you can refer to the [official documentation](https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-6.0).

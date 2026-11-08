# Architecture

BlazorDashboard is a .NET 10 dashboard starter. Aspire starts the web frontend and sample API as separate processes.

| Project | Responsibility |
| --- | --- |
| [AppHost](../AppHost.cs) | Starts `apiservice` and `webfrontend`, probes their health, and supplies the API reference to the frontend. |
| [Web](../../BlazorDashboard.Web/Program.cs) | Renders the Blazor dashboard and calls the API through a typed HTTP client. |
| [ApiService](../../BlazorDashboard.ApiService/Program.cs) | Serves sample forecasts at `/weatherforecast` and persisted orders at `/orders`. |
| [Data](../../BlazorDashboard.Data/DashboardDbContext.cs) | Maps SQL Server order results and calls the stored procedure. |
| [Database](../../BlazorDashboard.Database/BlazorDashboard.Database.sqlproj) | Defines the Orders table, the GetOrders procedure, and optional sample data. |
| [ServiceDefaults](../../BlazorDashboard.ServiceDefaults/Extensions.cs) | Shares health checks, service discovery, HTTP resilience, and OpenTelemetry configuration. |
| [Tests](../../BlazorDashboard.Tests/WebTests.cs) | Starts the AppHost and checks the dashboard and Weather pages over HTTP. |

The overview reads [sample data](../../BlazorDashboard.Web/Components/Dashboard/OverviewSampleData.cs) inside the web project. The Weather page follows a separate path through `WeatherApiClient` and the Aspire service name `apiservice`.

The API resolves a scoped `DashboardDbContext` and executes `dbo.GetOrders`. The database project builds a DACPAC for schema deployment.

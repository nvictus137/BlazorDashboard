# Architecture

BlazorDashboard is a .NET 10 dashboard starter. Aspire runs the Blazor frontend and API as separate processes. The API connects to a SQL Server database provisioned by the database project.

| Project | Responsibility |
| --- | --- |
| [AppHost](../AppHost.cs) | Starts `apiservice` and `webfrontend`, probes readiness, and supplies the API reference to the frontend. |
| [Web](../../BlazorDashboard.Web/Program.cs) | Hosts the Blazor routes, shared dashboard views, account screens, and HTTP error pages. |
| [Shared](../../BlazorDashboard.Shared/BlazorDashboard.Shared.csproj) | Holds account contracts, form state, style enums, layout contracts, and toast services. |
| [SharedWeb](../../BlazorDashboard.SharedWeb/BlazorDashboard.SharedWeb.csproj) | Provides reusable Razor components for forms, layout, alerts, and titles. |
| [ApiService](../../BlazorDashboard.ApiService/Program.cs) | Serves sample forecasts at `/weatherforecast` and SQL Server orders at `/orders`. |
| [Data](../../BlazorDashboard.Data/DashboardDbContext.cs) | Maps order records and executes `dbo.GetOrders` through EF Core. |
| [Database](../../BlazorDashboard.Database/BlazorDashboard.Database.sqlproj) | Defines the Orders table, stored procedure, and optional seed data in a DACPAC. |
| [ServiceDefaults](../../BlazorDashboard.ServiceDefaults/Extensions.cs) | Shares health checks, service discovery, HTTP resilience, and OpenTelemetry. |
| [Tests](../../BlazorDashboard.Tests/BlazorDashboard.Tests.csproj) | Contains the Aspire smoke test and SQL Server stored-procedure test. |

Home and the three Admin routes render [DashboardOverview](../../BlazorDashboard.Web/Components/Dashboard/DashboardOverview.razor) with one scoped stylesheet. The component uses [bundled sample data](../../BlazorDashboard.Web/Components/Dashboard/OverviewSampleData.cs). The Weather page calls the API through [WeatherApiClient](../../BlazorDashboard.Web/WeatherApiClient.cs). Persisted orders are available separately through the API.

## Open review items

- Complete account service wiring and enforce authentication and authorization before adding administrative operations.
- Bound the result set in [dbo.GetOrders](<../../BlazorDashboard.Database/dbo/Stored Procedures/GetOrders.sql>) before connecting the dashboard to a large order dataset. Use a stable sort key that matches the intended ordering.
- Reduce timer allocations and render requests in [CountdownTimer](../../BlazorDashboard.Shared/Alerts/Toaster/CountdownTimer.cs) and dispose toast event subscriptions in [Toasts](../../BlazorDashboard.SharedWeb/Alerts/Toaster/Toasts.razor.cs).
- Review the Bootstrap files copied to publish output. [App.razor](../../BlazorDashboard.Web/Components/App.razor) loads the minified CSS and bundle.

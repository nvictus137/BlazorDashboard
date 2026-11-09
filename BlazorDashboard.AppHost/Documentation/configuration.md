# Configuration

Run these commands from the repository root.

## Run through Aspire

```powershell
dotnet run --project .\BlazorDashboard.AppHost
```

Open the Aspire dashboard URL printed in the terminal and follow the `webfrontend` endpoint. AppHost uses its [launch profiles](../Properties/launchSettings.json), and the root [Aspire configuration](../../aspire.config.json) identifies the AppHost project.

| Setting | Behavior |
| --- | --- |
| `HealthChecks__ExposeReadinessEndpoint` | AppHost enables `/health` for the Web and API resources outside Development. |
| `OTEL_EXPORTER_OTLP_ENDPOINT` | Enables the OTLP exporter in ServiceDefaults when set. |
| `ConnectionStrings__Dashboard` | Overrides the SQL Server connection string in the API environment. |

In Development, ServiceDefaults maps both `/health` and `/alive`.

## Run the Web and API projects directly

Start the API in one terminal.

```powershell
dotnet run --project .\BlazorDashboard.ApiService --launch-profile http
```

Start the frontend in a second terminal.

```powershell
dotnet run --project .\BlazorDashboard.Web --launch-profile standalone
```

Open the dashboard on port 5096. The standalone profile maps `apiservice` to `http://localhost:5559` for Weather requests. [Dashboard](http://localhost:5096/) · [Web launch profiles](../../BlazorDashboard.Web/Properties/launchSettings.json)

## SQL Server

Build the database project in Visual Studio with SQL Server Data Tools, then publish the DACPAC before using `/orders`. The API Development configuration targets the `BlazorDashboard` database on `.\SQLEXPRESS2022` with Windows authentication. Set the publish variable `SeedSampleOrders` to `true` to insert the five sample orders. The API uses the same connection setting in both launch modes. [Development settings](../../BlazorDashboard.ApiService/appsettings.Development.json) · [Database project](../../BlazorDashboard.Database/BlazorDashboard.Database.sqlproj)

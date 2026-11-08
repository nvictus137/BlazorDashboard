# Configuration

Run from the repository root with the .NET 10 SDK and the Aspire CLI available.

```powershell
dotnet run --project .\BlazorDashboard.AppHost
```

Open the Aspire dashboard URL printed in the terminal and follow the `webfrontend` endpoint. The AppHost uses its [launch profiles](../Properties/launchSettings.json) for local dashboard addresses and environment settings. The root [aspire.config.json](../../aspire.config.json) points the CLI to the AppHost project.

| Setting | Behavior |
| --- | --- |
| `HealthChecks__ExposeReadinessEndpoint` | AppHost sets this to `true` for the web and API services. It enables `/health` outside Development. |
| `OTEL_EXPORTER_OTLP_ENDPOINT` | Enables the OTLP exporter in ServiceDefaults when set. |
| `ConnectionStrings__Dashboard` | Overrides the SQL Server connection string used by the API. |

In Development, ServiceDefaults maps both `/health` and `/alive`. The web frontend resolves its Weather API through the Aspire resource name `apiservice`.

## Run the Web and API projects directly

Start the API from the repository root in one terminal.

```powershell
dotnet run --project .\BlazorDashboard.ApiService --launch-profile http
```

Start the frontend in a second terminal.

```powershell
dotnet run --project .\BlazorDashboard.Web --launch-profile standalone
```

Open [the Blazor dashboard](http://localhost:5096/). The Web project's [standalone launch profile](../../BlazorDashboard.Web/Properties/launchSettings.json) supplies `services__apiservice__http__0=http://localhost:5559` for service discovery. It applies when that profile is selected.

## SQL Server

Build the database project in Visual Studio with SQL Server Data Tools. Publish the DACPAC before serving order requests. For local development, publish to the `BlazorDashboard` database on `.\SQLEXPRESS2022` using Windows authentication. Set the `SeedSampleOrders` publish variable to `true` to insert the five sample orders.

Set `ConnectionStrings__Dashboard` in the API environment to use another SQL Server database. The API reads the same setting under Aspire and the standalone launch profile.

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
| `Database__Path` | Overrides the SQLite file path. Relative paths resolve against the API's content root. |

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

## SQLite

The API's `Database:Path` setting defaults to `App_Data/dashboard.db`. Both the Aspire and standalone launch profiles use the API project as the content root. The default database directory and `.db` files are excluded from Git.

Development startup applies pending EF Core migrations. For other environments, apply migrations before serving database requests. Run these commands from the repository root to apply migrations to the local default database.

```powershell
dotnet tool restore
dotnet ef database update --project .\BlazorDashboard.Data --startup-project .\BlazorDashboard.ApiService -- --contentRoot "$PWD\BlazorDashboard.ApiService"
```

To create a migration after editing the data model, run the following command from the repository root. Replace `DescribeChange` with the migration name.

```powershell
dotnet ef migrations add DescribeChange --project .\BlazorDashboard.Data --startup-project .\BlazorDashboard.ApiService -- --contentRoot "$PWD\BlazorDashboard.ApiService"
```

The local EF tool and EF Core packages use version `10.0.14`. Set `Database__Path` before running either the API or EF commands when targeting another database file.

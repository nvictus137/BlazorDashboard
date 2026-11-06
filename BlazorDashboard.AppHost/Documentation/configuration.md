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

In Development, ServiceDefaults maps both `/health` and `/alive`. The web frontend resolves its Weather API through the Aspire resource name `apiservice`.

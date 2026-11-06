# BlazorDashboard

An AdminLTE-inspired admin dashboard starter built with ASP.NET Core 10, Blazor, Bootstrap 5, and Aspire.

## Run locally

From the repository root, run the Aspire AppHost with the .NET 10 SDK:

```powershell
dotnet run --project .\BlazorDashboard.AppHost
```

Open the Aspire dashboard URL printed in the terminal and follow the **webfrontend** endpoint to the app. The AppHost also starts **apiservice** for the Weather API example.

## Customize the template

- `BlazorDashboard.Web/Components/Layout` contains the shared shell and sidebar navigation.
- `BlazorDashboard.Web/Components/Pages/Home.razor` contains the overview, including sample metrics, revenue, fulfillment, and filterable orders.
- `BlazorDashboard.Web/Components/Dashboard/MetricCard.razor` is a reusable KPI card.

The overview uses illustrative data from `BlazorDashboard.Web/Components/Dashboard/OverviewSampleData.cs`. The Weather API page demonstrates fetching data from a service discovered through Aspire.

## Run the smoke test

```powershell
dotnet test .\BlazorDashboard.Tests
```

The layout takes inspiration from [AdminLTE](https://github.com/ColorlibHQ/AdminLTE).

# Coding samples

## Reuse the dashboard overview

Home and Admin render the sales overview and orders filter. The Users page supplies its own metrics and hides the sales summary.

```razor
@rendermode InteractiveServer
@using BlazorDashboard.Web.Components.Dashboard

<PageTitle>User Management</PageTitle>

<DashboardOverview Title="User Management" ShowRevenue="false">
    <Metrics>
        <MetricCard Label="Total Users" Value="100" Change="+12.4%" />
    </Metrics>
</DashboardOverview>
```

Keep styles for the overview beside the component. See the full [Users page](../../BlazorDashboard.Web/Components/Pages/Admin/User-Management.razor) and [DashboardOverview stylesheet](../../BlazorDashboard.Web/Components/Dashboard/DashboardOverview.razor.css).

## Call the API

The [Weather page](../../BlazorDashboard.Web/Components/Pages/Weather.razor) injects [WeatherApiClient](../../BlazorDashboard.Web/WeatherApiClient.cs) and displays loading, success, and failure states. Web startup configures the client with the Aspire service name `apiservice`. [Web startup](../../BlazorDashboard.Web/Program.cs)

## Read SQL Server orders

The API injects the scoped `DashboardDbContext`, then forwards the request's cancellation token to `GetOrdersAsync`. The context calls `dbo.GetOrders` and materializes read-only results. [API endpoint](../../BlazorDashboard.ApiService/Program.cs) · [Data context](../../BlazorDashboard.Data/DashboardDbContext.cs)

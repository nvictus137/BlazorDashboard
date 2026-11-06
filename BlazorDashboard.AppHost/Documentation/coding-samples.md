# Coding samples

## Add a KPI card

Import the dashboard components namespace in a Razor page and pass the display values to `MetricCard`.

```razor
@using BlazorDashboard.Web.Components.Dashboard

<MetricCard Label="Orders" Value="1,248" Change="+8.2%" />
```

The card implementation lives in [MetricCard.razor](../../BlazorDashboard.Web/Components/Dashboard/MetricCard.razor). See [Home.razor](../../BlazorDashboard.Web/Components/Pages/Home.razor) for a grid of cards and an example of deriving a display value from sample data.

## Call an Aspire service

The [Weather page](../../BlazorDashboard.Web/Components/Pages/Weather.razor) injects [WeatherApiClient](../../BlazorDashboard.Web/WeatherApiClient.cs) and awaits `GetWeatherAsync()`. The page shows a loading state, a forecast table, or an error message. The API address is configured in [Web/Program.cs](../../BlazorDashboard.Web/Program.cs).

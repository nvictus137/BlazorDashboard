# Testing

Run the Aspire integration smoke test from the repository root.

```powershell
dotnet test .\BlazorDashboard.Tests
```

[WebTests.cs](../../BlazorDashboard.Tests/WebTests.cs) starts AppHost, waits for `webfrontend` to become healthy, then verifies that the dashboard and forecast table render over HTTP. If the test times out in `StartAsync`, inspect the captured Aspire startup output. The HTTP assertions run after startup completes.

## Manual checks

1. Open `webfrontend` from the Aspire dashboard and verify the overview cards and chart render.
2. Filter orders by status, then select **All statuses** and verify the full table returns.
3. At a narrow viewport, open the navigation drawer and navigate to the Counter page. Verify the button updates the count.
4. Open the Weather page and verify the forecast table renders with the API running.

## SQL Server orders

Publish the DACPAC to a dedicated SQL Server test database with `SeedSampleOrders=true`. Set `DashboardTestConnectionString` to its connection string, then run the database test independently of Aspire startup.

```powershell
dotnet test .\BlazorDashboard.Tests --filter FullyQualifiedName~DataTests
```

The test checks the order, amount, and customer data returned by the stored procedure. With the standalone API running, open `http://localhost:5559/orders` to query persisted orders.

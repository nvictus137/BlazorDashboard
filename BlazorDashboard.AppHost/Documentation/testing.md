# Testing

Build the full solution in Visual Studio with SQL Server Data Tools. The account route and dashboard consolidation checks used a standalone Web process. They verified HTTP 200 for the account and dashboard routes, HTTP 404 for a missing route, and interactive filter and reset behavior on all four dashboard pages.

## Aspire smoke test

Run from the repository root.

```powershell
dotnet test .\BlazorDashboard.Tests --filter FullyQualifiedName~WebTests
```

The test starts AppHost, waits for `webfrontend` to become healthy, and verifies the overview and Weather table. If it times out during `StartAsync`, inspect the captured Aspire startup output. The HTTP assertions run after AppHost starts. [WebTests.cs](../../BlazorDashboard.Tests/WebTests.cs)

## SQL Server orders

Publish the DACPAC to a dedicated test database with `SeedSampleOrders=true`. Set `DashboardTestConnectionString` to that database's connection string and run the data test.

```powershell
dotnet test .\BlazorDashboard.Tests --filter FullyQualifiedName~DataTests
```

The test checks the five sample IDs, order, decimal total, and customer data returned by the stored procedure. It skips when the connection string is absent. [DataTests.cs](../../BlazorDashboard.Tests/DataTests.cs)

## Manual checks

1. On `/` and `/Admin`, verify the metrics, revenue chart, and fulfillment indicators. Verify the separate headings and Users metrics on `/Admin/Users` and `/Admin/Roles`.
2. On all four dashboard routes, select **Completed** in the status filter and verify that three of five orders appear. Select **All statuses** and verify that all five return.
3. Open `/login`, `/register`, and `/forgot-password`. In the default setup, each route should display its unavailable message.
4. Request a missing URL and verify that the 404 page retains HTTP 404. Check `/weather` and the API's `/orders` endpoint with the API and database available.

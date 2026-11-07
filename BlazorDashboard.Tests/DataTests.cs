using BlazorDashboard.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BlazorDashboard.Tests;

public class DataTests
{
    [Fact]
    public async Task MigrationsPreserveSavedOrdersWhenAppliedAgain()
    {
        var cancellationToken = TestContext.Current.CancellationToken;
        var databasePath = Path.Combine(Path.GetTempPath(), $"dashboard-{Guid.NewGuid():N}.db");
        var connectionString = new SqliteConnectionStringBuilder
        {
            DataSource = databasePath,
            Pooling = false
        }.ToString();
        var options = new DbContextOptionsBuilder<DashboardDbContext>().UseSqlite(connectionString).Options;

        try
        {
            await using (var database = new DashboardDbContext(options))
            {
                await database.Database.MigrateAsync(cancellationToken);
                Assert.Equal(5, await database.Orders.CountAsync(cancellationToken));
                database.Orders.Add(new DashboardOrder
                {
                    Id = "#test",
                    Customer = "Persistence test",
                    Status = "Pending",
                    Total = 12.34m
                });
                await database.SaveChangesAsync(cancellationToken);
            }

            await using (var database = new DashboardDbContext(options))
            {
                await database.Database.MigrateAsync(cancellationToken);
                Assert.Empty(await database.Database.GetPendingMigrationsAsync(cancellationToken));
                var savedOrder = await database.Orders.SingleAsync(order => order.Id == "#test", cancellationToken);
                Assert.Equal(12.34m, savedOrder.Total);
                Assert.Equal(6, await database.Orders.CountAsync(cancellationToken));
            }
        }
        finally
        {
            File.Delete(databasePath);
        }
    }
}

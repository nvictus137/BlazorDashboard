using BlazorDashboard.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorDashboard.Tests;

public class DataTests
{
    [Fact]
    public async Task GetOrdersReadsSeededOrdersFromSqlServer()
    {
        var connectionString = Environment.GetEnvironmentVariable("DashboardTestConnectionString");
        Assert.SkipWhen(string.IsNullOrWhiteSpace(connectionString),
            "Set DashboardTestConnectionString to a seeded SQL Server test database.");

        var options = new DbContextOptionsBuilder<DashboardDbContext>().UseSqlServer(connectionString).Options;
        await using var database = new DashboardDbContext(options);
        var orders = await database.GetOrdersAsync(TestContext.Current.CancellationToken);

        Assert.Equal(["#1048", "#1047", "#1046", "#1045", "#1044"], orders.Select(order => order.Id));
        Assert.Equal(185.50m, orders[1].Total);
        Assert.Equal("Oak & Finch", orders[1].Customer);
    }
}

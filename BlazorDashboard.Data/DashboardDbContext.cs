using Microsoft.EntityFrameworkCore;

namespace BlazorDashboard.Data;

public sealed class DashboardDbContext(DbContextOptions<DashboardDbContext> options) : DbContext(options)
{
    public DbSet<DashboardOrder> Orders => Set<DashboardOrder>();

    public Task<DashboardOrder[]> GetOrdersAsync(CancellationToken cancellationToken) =>
        Orders.FromSqlRaw("EXEC [dbo].[GetOrders]")
            .AsNoTracking()
            .ToArrayAsync(cancellationToken);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var orders = modelBuilder.Entity<DashboardOrder>();
        orders.ToTable("Orders", "dbo");
        orders.HasKey(order => order.Id);
        orders.Property(order => order.Id).HasMaxLength(128).ValueGeneratedNever();
        orders.Property(order => order.Customer).HasMaxLength(256).IsRequired();
        orders.Property(order => order.Status).HasMaxLength(32).IsRequired();
        orders.Property(order => order.Total).HasPrecision(18, 2);
    }
}

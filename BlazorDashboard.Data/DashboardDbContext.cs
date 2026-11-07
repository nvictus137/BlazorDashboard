using Microsoft.EntityFrameworkCore;

namespace BlazorDashboard.Data;

public sealed class DashboardDbContext(DbContextOptions<DashboardDbContext> options) : DbContext(options)
{
    public DbSet<DashboardOrder> Orders => Set<DashboardOrder>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var orders = modelBuilder.Entity<DashboardOrder>();
        orders.ToTable("Orders");
        orders.HasKey(order => order.Id);
        orders.Property(order => order.Id).ValueGeneratedNever();
        orders.Property(order => order.Customer).IsRequired();
        orders.Property(order => order.Status).IsRequired();
        orders.HasData(
            new DashboardOrder { Id = "#1048", Customer = "Northstar Studio", Status = "Completed", Total = 324.00m },
            new DashboardOrder { Id = "#1047", Customer = "Oak & Finch", Status = "Processing", Total = 185.50m },
            new DashboardOrder { Id = "#1046", Customer = "Harbor Supply", Status = "Completed", Total = 620.00m },
            new DashboardOrder { Id = "#1045", Customer = "Juniper Labs", Status = "Pending", Total = 92.40m },
            new DashboardOrder { Id = "#1044", Customer = "Summit Works", Status = "Completed", Total = 248.00m });
    }
}

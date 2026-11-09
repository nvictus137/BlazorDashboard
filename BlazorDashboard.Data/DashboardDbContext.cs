using Microsoft.EntityFrameworkCore;

namespace BlazorDashboard.Data;

public sealed class DashboardDbContext(DbContextOptions<DashboardDbContext> options) : DbContext(options)
{
    public DbSet<DashboardOrder> Orders => Set<DashboardOrder>();
    public DbSet<DashboardUser> Users => Set<DashboardUser>();

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

        var users = modelBuilder.Entity<DashboardUser>();
        users.ToTable("User", "dbo");
        users.HasKey(user => user.Id);
        users.Property(user => user.Id).UseIdentityColumn();
        users.Property(user => user.UserName).HasMaxLength(256);
        users.Property(user => user.NormalizedUserName).HasMaxLength(256);
        users.Property(user => user.Email).HasMaxLength(256);
        users.Property(user => user.NormalizedEmail).HasMaxLength(256);
        users.Property(user => user.PhoneNumber).HasMaxLength(256);
        users.Property(user => user.ConcurrencyStamp).IsConcurrencyToken();
        users.Property(user => user.Title).HasMaxLength(64).IsRequired();
        users.Property(user => user.FirstName).HasMaxLength(128).IsRequired();
        users.Property(user => user.LastName).HasMaxLength(128).IsRequired();
        users.Property(user => user.Created).HasDefaultValueSql("SYSUTCDATETIME()", "DF_User_Created");
        users.HasIndex(user => user.NormalizedUserName)
            .HasDatabaseName("UX_User_NormalizedUserName")
            .IsUnique()
            .HasFilter("[NormalizedUserName] IS NOT NULL");
        users.HasIndex(user => user.NormalizedEmail)
            .HasDatabaseName("UX_User_NormalizedEmail")
            .IsUnique()
            .HasFilter("[NormalizedEmail] IS NOT NULL");
    }
}

namespace BlazorDashboard.Web.Components.Dashboard;

internal static class OverviewSampleData
{
    public static IReadOnlyList<(string Name, decimal Amount)> WeeklyRevenue { get; } =
    [
        ("Mon", 4800), ("Tue", 6100), ("Wed", 5620), ("Thu", 7350),
        ("Fri", 6880), ("Sat", 8900), ("Sun", 8640)
    ];

    public static IReadOnlyList<string> OrderStatuses { get; } = ["Completed", "Processing", "Pending"];

    public static IReadOnlyList<SampleOrder> RecentOrders { get; } =
    [
        new("#1048", "Northstar Studio", "Completed", 324.00m),
        new("#1047", "Oak & Finch", "Processing", 185.50m),
        new("#1046", "Harbor Supply", "Completed", 620.00m),
        new("#1045", "Juniper Labs", "Pending", 92.40m),
        new("#1044", "Summit Works", "Completed", 248.00m)
    ];
}

internal sealed record SampleOrder(string Id, string Customer, string Status, decimal Total);

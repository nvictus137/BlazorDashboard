namespace BlazorDashboard.Data;

public sealed class DashboardOrder
{
    public string Id { get; set; } = "";
    public string Customer { get; set; } = "";
    public string Status { get; set; } = "";
    public decimal Total { get; set; }
}

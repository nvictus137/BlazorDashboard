using Microsoft.AspNetCore.Identity;

namespace BlazorDashboard.Data;

public sealed class DashboardUser : IdentityUser<int>
{
    public string Title { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public bool AcceptTerms { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}

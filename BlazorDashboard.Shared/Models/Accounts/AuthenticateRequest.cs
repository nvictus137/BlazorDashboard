using System.ComponentModel.DataAnnotations;

namespace BlazorDashboard.Shared.Models.Accounts;

public class AuthenticateRequest
{
    [EmailAddress]
    public required string Email { get; set; }

    public required string Password { get; set; }
}
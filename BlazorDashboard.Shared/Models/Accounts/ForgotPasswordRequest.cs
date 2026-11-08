using System.ComponentModel.DataAnnotations;

namespace BlazorDashboard.Shared.Models.Accounts;

public class ForgotPasswordRequest
{
    [EmailAddress]
    public required string Email { get; set; }
}
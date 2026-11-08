using System.ComponentModel.DataAnnotations;

namespace BlazorDashboard.Shared.Models.Accounts;

public class ResetPasswordRequest
{
    public required string Token { get; set; }

    [MinLength(6)]
    public required string Password { get; set; }

    [Compare("Password")]
    public required string ConfirmPassword { get; set; }
}
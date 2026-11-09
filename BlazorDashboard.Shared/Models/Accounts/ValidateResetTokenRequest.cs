using System.ComponentModel.DataAnnotations;

namespace BlazorDashboard.Shared.Models.Accounts;

public class ValidateResetTokenRequest
{
    [Required]
    public string Token { get; set; }
}
using System.ComponentModel.DataAnnotations;
using BlazorDashboard.Shared.Helpers;

namespace BlazorDashboard.Shared.Models.Accounts;

public class RegisterRequest
{
    public required string Title { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    [Email]
    public required string Email { get; set; }

    [MinLength(6)]
    public required string Password { get; set; }

    [Compare("Password")]
    public required string ConfirmPassword { get; set; }

    [Range(typeof(bool), "true", "true")]
    public bool AcceptTerms { get; set; }
}
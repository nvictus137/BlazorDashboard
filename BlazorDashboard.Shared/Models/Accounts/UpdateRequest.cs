using BlazorDashboard.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlazorDashboard.Shared.Models.Accounts;

public class UpdateRequest
{
    public string Title { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    [EnumDataType(typeof(Role))]
    public string? Role
    {
        get;
        set => field = string.IsNullOrEmpty(value) ? null : value;
    }

    [EmailAddress]
    public string? Email
    {
        get;
        set => field = string.IsNullOrEmpty(value) ? null : value;
    }

    [MinLength(6)]
    public string? Password
    {
        get;
        set => field = string.IsNullOrEmpty(value) ? null : value;
    }

    [Compare("Password")]
    public string? ConfirmPassword
    {
        get;
        set => field = string.IsNullOrEmpty(value) ? null : value;
    }
}
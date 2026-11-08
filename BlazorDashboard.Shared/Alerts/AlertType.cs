using BlazorDashboard.Shared.Enumerations;

namespace BlazorDashboard.Shared.Alerts;

public enum AlertType
{
    [Style("danger")]
    Danger,
    [Style("info")]
    Info,
    [Style("warning")]
    Warning,
    [Style("success")]
    Success
}

using Microsoft.AspNetCore.Components;

namespace BlazorDashboard.Shared.Forms;

public class CustomCheckboxState
{
    public bool? IsChecked { get; set; }
    public bool IsDisabled { get; set; }
    public string Value { get; set; } = string.Empty;
    public string Identifier { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
}

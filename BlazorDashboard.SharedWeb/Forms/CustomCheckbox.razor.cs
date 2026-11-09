using System.Xml.Linq;
using BlazorDashboard.Shared.Forms;
using Microsoft.AspNetCore.Components;

namespace BlazorDashboard.SharedWeb.Forms;

public partial class CustomCheckbox
{
    [Parameter]
    public CustomCheckboxState Value { get; set; }

    [Parameter]
    public EventCallback<CustomCheckboxState>ValueChanged { get; set; }

    [Parameter]
    public EventCallback<CustomCheckboxState> OnChange { get; set; }

    private void DoChange(ChangeEventArgs e)
    {
        Value.IsChecked = (bool?)e.Value;
        ValueChanged.InvokeAsync(Value);
        if (OnChange.HasDelegate)
          OnChange.InvokeAsync(Value);
    }
}

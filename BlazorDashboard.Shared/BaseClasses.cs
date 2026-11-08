using Microsoft.AspNetCore.Components;

namespace BlazorDashboard.Shared;

public class BaseClasses : ComponentBase
{
    [Parameter]
    public object Classes
    {
        get
        {
            return classes;
        }
        set
        {
            classes = value.ToString();
        }
    }

    public string classes { get; set; } = "";
}

using Microsoft.JSInterop;

namespace BlazorDashboard.Shared.Layout;

public class LayoutManager : ILayoutManager
{
    public bool IsSideBarFixed
    {
        get;
        set { field = value; js.InvokeVoidAsync("sideBarFixed", value); }
    }

    public bool IsNavBarFixed
    {
        get;
        set { field = value; js.InvokeVoidAsync("navBarFixed", value); }
    }

    public bool IsFooterFixed
    {
        get;
        set { field = value; js.InvokeVoidAsync("footerFixed", value); }
    }

    private readonly IJSRuntime js;

    public LayoutManager(IJSRuntime js)
    {
        this.js = js;
    }

    public void OverlayMode(bool isOverlayMode)
    {
        if (isOverlayMode)
        {
            js.InvokeVoidAsync("navBarFixed", false);
            js.InvokeVoidAsync("footerFixed", false);
        }
        else
        {
            js.InvokeVoidAsync("navBarFixed", IsNavBarFixed);
            js.InvokeVoidAsync("footerFixed", IsFooterFixed);
        }
    }
}

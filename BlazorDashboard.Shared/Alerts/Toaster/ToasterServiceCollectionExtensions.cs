using BlazorDashboard.Shared.Alerts.Toaster.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorDashboard.Shared.Alerts.Toaster;

public static class ToasterServiceCollectionExtensions
{
    public static IServiceCollection AddToast(this IServiceCollection services)
    {
        return services.AddScoped<IToastService, ToastService>();
    }
}

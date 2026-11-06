using Microsoft.Extensions.Logging;

[assembly: CaptureConsole]

namespace BlazorDashboard.Tests;

public class WebTests
{
    private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(1);

    [Fact]
    public async Task DashboardAndWeatherRenderThroughAspire()
    {
        using var timeout = CancellationTokenSource.CreateLinkedTokenSource(TestContext.Current.CancellationToken);
        timeout.CancelAfter(TestTimeout);
        var cancellationToken = timeout.Token;

        var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.BlazorDashboard_AppHost>(cancellationToken);
        appHost.Services.AddLogging(logging => logging.AddSimpleConsole());

        await using var app = await appHost.BuildAsync(cancellationToken);
        await app.StartAsync(cancellationToken);
        await app.ResourceNotifications.WaitForResourceHealthyAsync("webfrontend", cancellationToken);

        using var httpClient = app.CreateHttpClient("webfrontend");
        using var dashboard = await httpClient.GetAsync("/", cancellationToken);
        Assert.Equal(HttpStatusCode.OK, dashboard.StatusCode);
        Assert.Contains("Dashboard overview", await dashboard.Content.ReadAsStringAsync(cancellationToken));

        using var weather = await httpClient.GetAsync("/weather", cancellationToken);
        Assert.Equal(HttpStatusCode.OK, weather.StatusCode);
        Assert.Contains("Temperature in Celsius", await weather.Content.ReadAsStringAsync(cancellationToken));
    }
}

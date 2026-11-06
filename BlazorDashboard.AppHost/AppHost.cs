var builder = DistributedApplication.CreateBuilder(args);
const string exposeReadiness = "HealthChecks__ExposeReadinessEndpoint";

var apiService = builder.AddProject<Projects.BlazorDashboard_ApiService>("apiservice")
    .WithEnvironment(exposeReadiness, "true")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.BlazorDashboard_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithEnvironment(exposeReadiness, "true")
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();

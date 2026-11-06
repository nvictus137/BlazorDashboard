var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.BlazorDashboard_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.BlazorDashboard_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();

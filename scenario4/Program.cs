using BasicWorkflowSamples;
using Dapr.Workflow;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDaprWorkflow(options =>
{
    options.RegisterWorkflow<HelloWorldWorkflow>();
    options.RegisterActivity<CreateGreetingActivity>();
});

if(string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DAPR_GRPC_PORT")))
{
    Environment.SetEnvironmentVariable("DAPR_GRPC_PORT", "50001");
}

var app = builder.Build();

app.Run();

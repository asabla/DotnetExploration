using DotnetExploration.Web.MinimalApi.Endpoints.V1;
using DotnetExploration.Web.MinimalApi.Endpoints.V2;
using DotnetExploration.Web.MinimalApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Load and setup configurations
builder.ConfigurationSetup();

// Load and setup swagger
builder.WebAppBuilderSwaggerSetup();

var app = builder.Build();

// Security settings
app.UseHttpsRedirection();

// Setup swagger UI in development
app.WebAppSwaggerSetup(
    app.Environment.IsDevelopment(),
    builder.Environment.ApplicationName);

// Map all endpoints
app.MapTodoV1();
app.MapTodoV2();

app.Run();

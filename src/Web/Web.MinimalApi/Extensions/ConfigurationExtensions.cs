using DotnetExploration.Web.MinimalApi.Models.Settings;
using DotnetExploration.Web.MinimalApi.Validations;

using FluentValidation;

namespace DotnetExploration.Web.MinimalApi.Extensions;

public static class ConfigurationExtensions
{
    public static WebApplicationBuilder ConfigurationSetup(this WebApplicationBuilder builder)
    {
        // Configure setup
        builder.Configuration
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);

        // Validate configuration on startup
        // builder.Services.AddOptions<ApiSettings>()
        //     .BindConfiguration(nameof(ApiSettings))
        //     .ValidateDataAnnotations()
        //     .Validate(x =>
        //         x is default(ApiSettings) || x.WebhookUrl.StartsWith("https://"),
        //         $"{nameof(ApiSettings.WebhookUrl)} must start with https://")
        //     .ValidateOnStart();

        // Fluent validation alternative
        builder.Services.AddScoped<IValidator<ApiSettings>, ApiSettingsValidator>();
        builder.Services.AddOptions<ApiSettings>()
            .BindConfiguration(nameof(ApiSettings))
            .ValidateWithFluent()
            .ValidateOnStart();

        return builder;
    }
}
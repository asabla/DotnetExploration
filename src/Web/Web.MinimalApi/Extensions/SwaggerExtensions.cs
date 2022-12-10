namespace DotnetExploration.Web.MinimalApi.Extensions;

public static class SwaggerExtensions
{
    public static WebApplicationBuilder WebAppBuilderSwaggerSetup(
        this WebApplicationBuilder builder)
    {
        // Swagger setup
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new()
            {
                Title = builder.Environment.ApplicationName,
                Version = "v1"
            });

            config.SwaggerDoc("v2", new()
            {
                Title = builder.Environment.ApplicationName,
                Version = "v2"
            });

            config.ResolveConflictingActions(apiDescriptions
                => apiDescriptions.FirstOrDefault());
        });

        return builder;
    }

    public static IApplicationBuilder WebAppSwaggerSetup(
        this IApplicationBuilder builder,
        bool isDevelopment,
        string applicationName)
    {
        if (isDevelopment)
        {
            builder.UseSwagger();
            builder.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint(
                    "/swagger/v1/swagger.json",
                    $"{applicationName} v1");

                config.SwaggerEndpoint(
                    "/swagger/v2/swagger.json",
                    $"{applicationName} v2");
            });
        }

        return builder;
    }
}
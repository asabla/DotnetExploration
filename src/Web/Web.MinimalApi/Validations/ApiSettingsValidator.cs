using DotnetExploration.Web.MinimalApi.Models.Settings;

using FluentValidation;

namespace DotnetExploration.Web.MinimalApi.Validations;

public class ApiSettingsValidator : AbstractValidator<ApiSettings>
{
    public ApiSettingsValidator()
    {
        RuleFor(x => x.WebhookUrl)
            .NotNull().NotEmpty()
            .MinimumLength(10)
            .Must(StringMustBeValidUri)
            .WithMessage($"{nameof(ApiSettings.WebhookUrl)} must be a valid uri starting with https://");

        RuleFor(x => x.DisplayName)
            .NotNull().NotEmpty()
            .MinimumLength(3)
            .WithMessage($"{nameof(ApiSettings.DisplayName)} must be at least 3 characters long");
    }

    private static bool StringMustBeValidUri(string argStr)
    {
        return Uri.TryCreate(argStr, UriKind.Absolute, out var resultUri)
            && resultUri.Scheme == Uri.UriSchemeHttps;
    }
}
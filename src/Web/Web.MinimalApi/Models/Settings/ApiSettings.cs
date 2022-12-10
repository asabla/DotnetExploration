using System.ComponentModel.DataAnnotations;

namespace DotnetExploration.Web.MinimalApi.Models.Settings;

public class ApiSettings
{
    [Required, Url, MinLength(10)]
    public string WebhookUrl { get; set; } = null!;

    [Required, MinLength(3)]
    public string DisplayName { get; set; } = null!;

    public bool Enabled { get; set; }
}
namespace DotnetExploration.Web.MinimalApi.Models.Responses;

public record TodoItem()
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Updated { get; set; } = DateTime.UtcNow;

    public string Name { get; set; } = null!;
    public string? Content { get; set; }
}
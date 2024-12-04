namespace RecipeBackend.Controllers.Responses;

public record RecipeDto
{
    public string? Title { get; set; }
    public string? Instructions { get; set; }
    public string? ImageUrl { get; set; }

    public DateTime EffectiveDate { get; set; } = DateTime.UtcNow;
    public string RecordSource { get; set; } = "API";
}

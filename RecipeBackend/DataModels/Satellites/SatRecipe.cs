using RecipeBackend.DataModels.Hubs;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RecipeBackend.DataModels.Satellites;

[PrimaryKey(nameof(RecipeId), nameof(LoadDate))]
public class SatRecipe
{
    public Guid RecipeId { get; set; }
    public DateTime LoadDate { get; set; }

    public string? Title { get; set; }
    public string? Instructions { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? RecordSource { get; set; }

    [ForeignKey("RecipeId")]
    public HubRecipe Recipe { get; set; }
}

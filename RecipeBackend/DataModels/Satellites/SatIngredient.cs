using RecipeBackend.DataModels.Hubs;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RecipeBackend.DataModels.Satellites;

[PrimaryKey(nameof(IngredientId), nameof(LoadDate))]
public class SatIngredient
{
    public Guid IngredientId { get; set; }
    public DateTime LoadDate { get; set; }

    public string Name { get; set; }
    public string Unit { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string RecordSource { get; set; }

    [ForeignKey("IngredientId")]
    public HubIngredient Ingredient { get; set; }
}

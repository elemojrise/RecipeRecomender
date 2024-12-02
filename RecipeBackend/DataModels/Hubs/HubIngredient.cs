using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecipeBackend.DataModels.Links.LinkIngredientAllergy;
using RecipeBackend.DataModels.Satellites;

namespace RecipeBackend.DataModels.Hubs;

public class HubIngredient
{
    [Key]
    public Guid IngredientId { get; set; }
    public DateTime LoadDate { get; set; }
    public string RecordSource { get; set; }

    [InverseProperty("Ingredient")]
    public ICollection<SatIngredient> SatIngredients { get; set; }

    [InverseProperty("Ingredient")]
    public ICollection<LinkIngredientAllergy> Allergies { get; set; }
}

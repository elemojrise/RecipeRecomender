using RecipeBackend.DataModels.Links.LinksRecipe;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBackend.DataModels.Hubs;

public class HubDietaryTag
{
    [Key]
    public Guid DietaryTagId { get; set; }
    public string Name { get; set; } // e.g., "Vegetarian", "Keto"
    public DateTime LoadDate { get; set; }
    public string RecordSource { get; set; }

    [InverseProperty("DietaryTag")]
    public ICollection<LinkRecipeDietaryTag> Recipes { get; set; }
}

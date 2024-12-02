using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecipeBackend.DataModels.Links.LinksRecipe;
using RecipeBackend.DataModels.Satellites;

namespace RecipeBackend.DataModels.Hubs;

public class HubRecipe
{
    [Key]
    public Guid RecipeId { get; set; }
    public DateTime LoadDate { get; set; }
    public string RecordSource { get; set; }

    [InverseProperty("Recipe")]
    public ICollection<SatRecipe> SatRecipes { get; set; }

    [InverseProperty("Recipe")]
    public ICollection<LinkRecipeCuisine> Cuisines { get; set; }

    [InverseProperty("Recipe")]
    public ICollection<LinkRecipeDietaryTag> DietaryTags { get; set; }
}

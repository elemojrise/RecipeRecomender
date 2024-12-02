using RecipeBackend.DataModels.Links.LinksPerson;
using RecipeBackend.DataModels.Links.LinksRecipe;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBackend.DataModels.Hubs;

public class HubCuisine
{
    [Key]
    public Guid CuisineId { get; set; }
    public string Name { get; set; } // e.g., "Italian", "Chinese"
    public DateTime LoadDate { get; set; }
    public string RecordSource { get; set; }

    [InverseProperty("Cuisine")]
    public ICollection<LinkPersonCuisinePreference> Persons { get; set; }

    [InverseProperty("Cuisine")]
    public ICollection<LinkRecipeCuisine> Recipes { get; set; }
}

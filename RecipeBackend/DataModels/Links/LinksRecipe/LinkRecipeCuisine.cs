using RecipeBackend.DataModels.Hubs;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RecipeBackend.DataModels.Links.LinksRecipe;

[PrimaryKey(nameof(RecipeId), nameof(CuisineId))]
public class LinkRecipeCuisine
{
    public Guid RecipeId { get; set; }
    public Guid CuisineId { get; set; }
    public DateTime LoadDate { get; set; }
    public string RecordSource { get; set; }

    [ForeignKey("RecipeId")]
    public HubRecipe Recipe { get; set; }

    [ForeignKey("CuisineId")]
    public HubCuisine Cuisine { get; set; }
}

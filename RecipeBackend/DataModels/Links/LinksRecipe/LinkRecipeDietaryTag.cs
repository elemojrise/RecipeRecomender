using RecipeBackend.DataModels.Hubs;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RecipeBackend.DataModels.Links.LinksRecipe;

[PrimaryKey(nameof(RecipeId), nameof(DietaryTagId))]
public class LinkRecipeDietaryTag
{
    public Guid RecipeId { get; set; }
    public Guid DietaryTagId { get; set; }

    public DateTime LoadDate { get; set; }
    public string RecordSource { get; set; }

    [ForeignKey("RecipeId")]
    public HubRecipe Recipe { get; set; }

    [ForeignKey("DietaryTagId")]
    public HubDietaryTag DietaryTag { get; set; }
}

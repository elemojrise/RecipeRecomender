using RecipeBackend.DataModels.Hubs;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecipeBackend.DataModels.Links.LinkIngredientAllergy;

[PrimaryKey(nameof(IngredientId), nameof(AllergyId))]
public class LinkIngredientAllergy
{
    public Guid IngredientId { get; set; }
    public Guid AllergyId { get; set; }
    public DateTime LoadDate { get; set; }
    public string RecordSource { get; set; }

    [ForeignKey("IngredientId")]
    public HubIngredient Ingredient { get; set; }

    [ForeignKey("AllergyId")]
    public HubAllergy Allergy { get; set; }
}

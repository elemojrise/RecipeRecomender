using RecipeBackend.DataModels.Links.LinkIngredientAllergy;
using RecipeBackend.DataModels.Links.LinksPerson;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBackend.DataModels.Hubs;

public class HubAllergy
{
    [Key]
    public Guid AllergyId { get; set; }
    public string Name { get; set; } // e.g., "Peanuts", "Shellfish", "Nuts"
    public DateTime LoadDate { get; set; }
    public string RecordSource { get; set; }

    [InverseProperty("Allergy")]
    public ICollection<LinkPersonAllergy> Persons { get; set; }

    [InverseProperty("Allergy")]
    public ICollection<LinkIngredientAllergy> Ingredients { get; set; }
}

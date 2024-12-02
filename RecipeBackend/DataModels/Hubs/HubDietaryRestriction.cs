using RecipeBackend.DataModels.Links.LinksPerson;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBackend.DataModels.Hubs;

public class HubDietaryRestriction
{
    [Key]
    public Guid DietaryRestrictionId { get; set; }
    public string Name { get; set; } // e.g., "Vegan", "Gluten-Free"
    public DateTime LoadDate { get; set; }
    public string RecordSource { get; set; }

    [InverseProperty("DietaryRestriction")]
    public ICollection<LinkPersonDietaryRestriction> Persons { get; set; }
}

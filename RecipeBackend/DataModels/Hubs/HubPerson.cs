using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecipeBackend.DataModels.Links.LinksPerson;
using RecipeBackend.DataModels.Satellites;
using RecipeBackend.Models;

namespace RecipeBackend.DataModels.Hubs;

public class HubPerson
{
    [Key]
    public Guid PersonId { get; set; }
    public DateTime LoadDate { get; set; }
    public string RecordSource { get; set; }

    public ApplicationUser ApplicationUser { get; set; }

    [InverseProperty("Person")]
    public ICollection<SatPerson> SatPersons { get; set; }

    [InverseProperty("Person")]
    public ICollection<LinkPersonDietaryRestriction> DietaryRestrictions { get; set; }
    
    [InverseProperty("Person")]
    public ICollection<LinkPersonCuisinePreference> CuisinePreferences { get; set; }
    
    [InverseProperty("Person")]
    public ICollection<LinkPersonAllergy> Allergies { get; set; }
    
    [InverseProperty("Person")]
    public ICollection<LinkPersonRecipe> Recipes { get; set; }
}

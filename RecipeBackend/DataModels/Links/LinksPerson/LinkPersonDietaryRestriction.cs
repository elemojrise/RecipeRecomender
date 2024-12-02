using RecipeBackend.DataModels.Hubs;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RecipeBackend.DataModels.Links.LinksPerson;

[PrimaryKey(nameof(PersonId), nameof(DietaryRestrictionId))]
public class LinkPersonDietaryRestriction
{

    public Guid PersonId { get; set; }
    public Guid DietaryRestrictionId { get; set; }
    public DateTime LoadDate { get; set; }
    public string RecordSource { get; set; }


    [ForeignKey("PersonId")]
    public HubPerson Person { get; set; }

    [ForeignKey("DietaryRestrictionId")]
    public HubDietaryRestriction DietaryRestriction { get; set; }
}

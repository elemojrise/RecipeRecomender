using RecipeBackend.DataModels.Hubs;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RecipeBackend.DataModels.Links.LinksPerson;

[PrimaryKey(nameof(PersonId), nameof(CuisineId))]
public class LinkPersonCuisinePreference
{
    public Guid PersonId { get; set; }
    public Guid CuisineId { get; set; }
    public DateTime LoadDate { get; set; }
    public string RecordSource { get; set; }

    [ForeignKey("PersonId")]
    public HubPerson Person { get; set; }

    [ForeignKey("CuisineId")]
    public HubCuisine Cuisine { get; set; }
}

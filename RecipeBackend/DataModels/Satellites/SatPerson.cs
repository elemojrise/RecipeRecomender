using RecipeBackend.DataModels.Hubs;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RecipeBackend.DataModels.Satellites;

[PrimaryKey(nameof(PersonId), nameof(LoadDate))]
public class SatPerson
{
    public Guid PersonId { get; set; }
    public DateTime LoadDate { get; set; }

    public string? Name { get; set; }
    public string? Email { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string RecordSource { get; set; }

    [ForeignKey("PersonId")]
    public HubPerson Person { get; set; }
}

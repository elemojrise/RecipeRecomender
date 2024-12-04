using Microsoft.AspNetCore.Identity;
using RecipeBackend.DataModels.Hubs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBackend.Models;

public class ApplicationUser : IdentityUser
{
    public DateTime DateJoined { get; set; }

    public Guid? PersonId { get; set; }

    [ForeignKey("PersonId")]
    public HubPerson Person { get; set; }
}

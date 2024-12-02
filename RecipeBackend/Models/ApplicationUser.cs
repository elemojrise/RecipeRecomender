using Microsoft.AspNetCore.Identity;

namespace RecipeBackend.Models;

public class ApplicationUser : IdentityUser
{
    public DateTime DateJoined { get; set; }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeBackend.DataModels.Hubs;
using RecipeBackend.DataModels.Links.LinkIngredientAllergy;
using RecipeBackend.DataModels.Links.LinksPerson;
using RecipeBackend.DataModels.Links.LinksRecipe;
using RecipeBackend.DataModels.Satellites;
using RecipeBackend.Models;

namespace RecipeBackend.Data;

public class ApplicationContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<HubPerson> HubPersons { get; set; }
    public DbSet<HubRecipe> HubRecipes { get; set; }
    public DbSet<HubIngredient> HubIngredients { get; set; }
    public DbSet<HubDietaryRestriction> HubDietaryRestrictions { get; set; }
    public DbSet<HubCuisine> HubCuisines { get; set; }
    public DbSet<HubAllergy> HubAllergies { get; set; }
    public DbSet<HubDietaryTag> HubDietaryTags { get; set; }

    public DbSet<LinkPersonDietaryRestriction> LinkPersonDietaryRestrictions { get; set; }
    public DbSet<LinkPersonCuisinePreference> LinkPersonCuisinePreferences { get; set; }
    public DbSet<LinkPersonAllergy> LinkPersonAllergies { get; set; }
    public DbSet<LinkRecipeCuisine> LinkRecipeCuisines { get; set; }
    public DbSet<LinkRecipeDietaryTag> LinkRecipeDietaryTags { get; set; }
    public DbSet<LinkIngredientAllergy> LinkIngredientAllergies { get; set; }

    public DbSet<SatPerson> SatPersons { get; set; }
    public DbSet<SatRecipe> SatRecipes { get; set; }
    public DbSet<SatIngredient> SatIngredients { get; set; }
}


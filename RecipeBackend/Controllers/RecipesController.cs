using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RecipeBackend.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    [HttpGet]
    [Route("Recipes")]
    public string GetRecipes()
    {
        return "Allowed recipes";
    }

}

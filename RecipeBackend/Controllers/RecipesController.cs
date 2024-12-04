using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBackend.Controllers.Responses;
using RecipeBackend.Data;
using RecipeBackend.DataModels.Hubs;
using RecipeBackend.DataModels.Satellites;
using System.Text.Json;

namespace RecipeBackend.Controllers;


[Route("api/[controller]")]
[ApiController]
public class RecipesController(IHttpClientFactory httpClientFactory,
                               ApplicationContext context) : ControllerBase
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient();

    [Authorize]
    [HttpGet("recommendations")]
    public async Task<IActionResult> GetRecommendations()
    {
        var randomRecipe = await context.HubRecipes
            .OrderBy(r => Guid.NewGuid())
            .Include(r => r.SatRecipes.Where(s => s.ExpiryDate == null))
            .FirstOrDefaultAsync();

        var recipe = randomRecipe?.SatRecipes.FirstOrDefault()?.Title;

        if (recipe == null)
        {
            return NotFound();
        }

        var response = await _httpClient.GetAsync($"http://recommendation-engine:5001/recommendations/{recipe}");
        if (response.IsSuccessStatusCode)
        {
            var jsonstring = await response.Content.ReadAsStringAsync();
            var recommendations = JsonSerializer.Deserialize<List<RecipeDto>>(jsonstring);
            return Ok(recommendations);
        }
        else
        {
            return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }

    }

    [HttpPost("add")]
    public async Task<IActionResult> AddRecipe([FromBody] RecipeDto recipeDto)
    {
        if (recipeDto == null)
        {
            return BadRequest("Recipe data is null.");
        }

        var hubRecipe = new HubRecipe
        {
            LoadDate = DateTime.UtcNow,
            RecordSource = recipeDto.RecordSource
        };

        context.HubRecipes.Add(hubRecipe);
        await context.SaveChangesAsync();

        var satRecipe = new SatRecipe
        {
            RecipeId = hubRecipe.RecipeId,
            Title = recipeDto.Title,
            Instructions = recipeDto.Instructions,
            ImageUrl = recipeDto.ImageUrl,
            LoadDate = DateTime.UtcNow,
            EffectiveDate = recipeDto.EffectiveDate,
            ExpiryDate = null, 
            RecordSource = recipeDto.RecordSource
        };

        context.SatRecipes.Add(satRecipe);
        await context.SaveChangesAsync();

        return Ok(recipeDto);
    }

}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RecipeBackend.Data;
using RecipeBackend.DataModels.Hubs;
using RecipeBackend.DataModels.Satellites;
using RecipeBackend.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RecipeBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(
    UserManager<ApplicationUser> _userManager,
    IConfiguration _configuration,
    ApplicationContext _context) : ControllerBase
{

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var loadDate = DateTime.UtcNow;
            var hubPerson = new HubPerson
            {
                PersonId = Guid.NewGuid(),
                LoadDate = loadDate,
                RecordSource = "Registration"
            };


            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                DateJoined = DateTime.UtcNow,
                PersonId = hubPerson.PersonId, 
                Person = hubPerson             
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var satPerson = new SatPerson
                {
                    PersonId = hubPerson.PersonId,
                    LoadDate = loadDate,
                    Name = model.Name,
                    Email = model.Email,
                    EffectiveDate = loadDate,
                    RecordSource = "Registration",
                    Person = hubPerson
                };

                _context.SatPersons.Add(satPerson);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok();
            }
            else
            {
                await transaction.RollbackAsync();
                return BadRequest(result.Errors);
            }
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while registering the user.");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }
        return Unauthorized();
    }

    private string GenerateJwtToken(ApplicationUser user)
    {
        var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.NameIdentifier, user.Id)
    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

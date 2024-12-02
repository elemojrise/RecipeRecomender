using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RecipeBackend.Controllers;

[Authorize(Policy = "WebPolicy")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}

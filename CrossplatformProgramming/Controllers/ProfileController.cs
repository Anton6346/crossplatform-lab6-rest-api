using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class ProfileController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

using Microsoft.AspNetCore.Mvc;

namespace CrossplatformProgramming.Api.Test
{
    public class courses : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

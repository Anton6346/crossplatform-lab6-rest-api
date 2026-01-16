using Microsoft.AspNetCore.Mvc;

namespace CrossplatformProgramming.Controllers.Api.v2
{
    public class CoursesApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

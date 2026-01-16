using Microsoft.AspNetCore.Mvc;

namespace CrossplatformProgramming.Controllers.Api.v1
{
    public class CoursesApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

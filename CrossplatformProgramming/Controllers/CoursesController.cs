using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CoursesController : Controller
{
    private readonly ApplicationDbContext _context;

    public CoursesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // LIST (JOIN)
    public IActionResult Index()
    {
        var courses = _context.Courses
            .Include(c => c.Category)
            .Include(c => c.Teacher)
            .ToList();

        return View(courses);
    }

    // DETAILS (JOIN)
    public IActionResult Details(int id)
    {
        var course = _context.Courses
            .Include(c => c.Category)
            .Include(c => c.Teacher)
            .FirstOrDefault(c => c.Id == id);

        if (course == null)
            return NotFound();

        return View(course);
    }
}

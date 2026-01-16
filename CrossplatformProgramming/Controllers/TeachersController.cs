using Microsoft.AspNetCore.Mvc;

public class TeachersController : Controller
{
    private readonly ApplicationDbContext _context;

    public TeachersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // LIST (directory list)
    public IActionResult Index()
    {
        var teachers = _context.Teachers.ToList();
        return View(teachers);
    }

    // ELEMENT-BY-ELEMENT
    public IActionResult Details(int id)
    {
        var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
        if (teacher == null)
            return NotFound();

        return View(teacher);
    }
}

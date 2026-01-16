using Microsoft.AspNetCore.Mvc;

public class CategoriesController : Controller
{
    private readonly ApplicationDbContext _context;

    public CategoriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Categories.ToList());
    }

    public IActionResult Details(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null)
            return NotFound();

        return View(category);
    }
}

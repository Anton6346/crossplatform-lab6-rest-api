using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class SearchController : Controller
{
    private readonly ApplicationDbContext _context;

    public SearchController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(
        DateTime? fromDate,
        DateTime? toDate,
        List<int> categoryIds,
        string titleStart,
        string titleEnd)
    {
        var query = _context.Courses
            .Include(c => c.Category)
            .Include(c => c.Teacher)
            .AsQueryable();

        if (fromDate.HasValue)
            query = query.Where(c => c.CreatedAt >= fromDate);

        if (toDate.HasValue)
            query = query.Where(c => c.CreatedAt <= toDate);

        if (categoryIds != null && categoryIds.Any())
            query = query.Where(c => categoryIds.Contains(c.CategoryId));

        if (!string.IsNullOrEmpty(titleStart))
            query = query.Where(c => c.Title.StartsWith(titleStart));

        if (!string.IsNullOrEmpty(titleEnd))
            query = query.Where(c => c.Title.EndsWith(titleEnd));

        return View(query.ToList());
    }
}

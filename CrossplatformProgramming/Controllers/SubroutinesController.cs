using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class SubroutinesController : Controller
{
    public IActionResult Index() => View();

    [HttpGet]
    public IActionResult Factorial() => View();

    [HttpPost]
    public IActionResult Factorial(int number)
    {
        long result = 1;
        for (int i = 1; i <= number; i++)
            result *= i;

        ViewBag.Result = result;
        ViewBag.Number = number;
        return View();
    }

    [HttpGet]
    public IActionResult Prime() => View();

    [HttpPost]
    public IActionResult Prime(int number)
    {
        bool isPrime = number > 1;
        for (int i = 2; i <= Math.Sqrt(number); i++)
            if (number % i == 0)
                isPrime = false;

        ViewBag.Number = number;
        ViewBag.IsPrime = isPrime;
        return View();
    }

    [HttpGet]
    public IActionResult Temperature() => View();

    [HttpPost]
    public IActionResult Temperature(double value, string type)
    {
        double result = type == "CtoF"
            ? value * 9 / 5 + 32
            : (value - 32) * 5 / 9;

        ViewBag.Result = result;
        return View();
    }
}

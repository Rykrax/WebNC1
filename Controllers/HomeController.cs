using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebNC1.Models;

namespace WebNC1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/login")]
    public IActionResult login()
    {
        return View();
    }

    [HttpGet("/home")]
    public IActionResult home()
    {
        return View();
    }

    [HttpGet("/register")]
    public IActionResult register()
    {
        return View();
    }

    [HttpGet("/test")]
    public IActionResult test()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleRoutingDemo.Models;

namespace SimpleRoutingDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
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

    /// <summary>
    /// This action is for even numbers
    /// </summary>
    public IActionResult EvenOnly(int id) => Content($"The number {id} is even.");
    /// <summary>
    /// This action is for odd numbers
    /// </summary>
    public IActionResult OddOnly(int id) => Content($"The number {id} is odd.");
    /// <summary>
    /// This action is for any number
    /// </summary>
    public IActionResult AnyID(int id) => Content($"The number {id} is neither even nor odd.");
    /// <summary>
    /// This action is for special numbers
    /// </summary>
    public IActionResult Special(int id) => Content($"The number {id} is special.");

}

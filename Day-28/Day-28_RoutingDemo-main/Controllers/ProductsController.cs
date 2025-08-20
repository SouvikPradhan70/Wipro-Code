using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RoutingDemo.Models;

namespace RoutingDemo.Controllers;

public class ProductsController : Controller
{

    public IActionResult Index()
    {
        ViewData["Message"] = "Products Catalog";
        return View();
    }

    public IActionResult Details(int id )
    {
        ViewData["ProductId"] = id;
        ViewData["Message"] = $"Details for product with Id: {id}";
        return View();
    }

}
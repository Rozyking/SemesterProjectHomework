using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DaggerheartProject.Models;
using DaggerheartProject.Data;

namespace DaggerheartProject.Controllers;

public class HomeController : Controller
{
    private readonly DaggerheartContext _context;

    public HomeController(DaggerheartContext context)
    {
        _context = context;
    }

    public IActionResult Index(int id)
    {
        var spotlight = _context.DaggerheartCharacters.FirstOrDefault(t => t.Id == 1);
        return View(spotlight);
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

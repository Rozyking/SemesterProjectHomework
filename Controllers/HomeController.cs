using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DaggerheartProject.Models;
using Models;

namespace DaggerheartProject.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var spotlight = DaggerheartCharacterData.All.FirstOrDefault(c => c.Id == 1); // pick any Id
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

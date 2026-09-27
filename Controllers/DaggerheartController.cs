using Microsoft.AspNetCore.Mvc;
using DaggerheartProject.Models;

namespace DaggerheartProject.Controllers;

public class DaggerheartController : Controller
{

    public IActionResult Index()
    {
        return View(DaggerheartCharacterData.All);
    }

    public IActionResult Details(int id)
    {
        var character = DaggerheartCharacterData.All.FirstOrDefault(t => t.Id == id);

        if (character == null)
        {
            return NotFound();  // Honest 404 from bad index
        }

        return View(character);
    }

    public IActionResult Create()
    {
        return View();
    }

}
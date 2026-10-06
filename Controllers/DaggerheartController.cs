using Microsoft.AspNetCore.Mvc;
using DaggerheartProject.Models;
using DaggerheartProject.Data;

namespace DaggerheartProject.Controllers;

public class DaggerheartController : Controller
{
    private readonly DaggerheartContext _context;

    public DaggerheartController(DaggerheartContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.DaggerheartCharacters.ToList());
    }

    public IActionResult Details(int id)
    {
        var character = _context.DaggerheartCharacters.FirstOrDefault(t => t.Id == id);

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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(DaggerheartCharacter DHCharacter)
    {
        if (!ModelState.IsValid)
        {
            return View(DHCharacter);
        }

        _context.DaggerheartCharacters.Add(DHCharacter);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}
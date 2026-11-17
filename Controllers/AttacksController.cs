using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DaggerheartProject.Data;
using DaggerheartProject.Models;
using DaggerheartProject.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace DaggerheartProject.Controllers;

[Authorize(Roles = "DungeonMaster")]
public class AttacksController : Controller
{
    private readonly DaggerheartContext _context;

    public AttacksController(DaggerheartContext context)
    {
        _context = context;
    }

    // GET: /Attacks/Create  (or /Attacks/Create?characterId=3 to preselect)
    public IActionResult Create(int? characterId)
    {
        var form = new CharacterAttacksViewModel
        {
            Attack = new Attacks(),
            Characters = BuildCharacterList(characterId)
        };
        return View(form);
    }

    // POST: /Attacks/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CharacterAttacksViewModel form)
    {
        if (!ModelState.IsValid)
        {
            // Rebuild the list, or the dropdown comes back empty.
            form.Characters = BuildCharacterList(form.Attack.DaggerheartCharacterId);
            return View(form);
        }

        _context.Attacks.Add(form.Attack);
        _context.SaveChanges();

        // Send them to the character's page, where the new attack should now appear.
        return RedirectToAction("Details", "Daggerheart",
            new { id = form.Attack.DaggerheartCharacterId });
    }

    private SelectList BuildCharacterList(int? selectedId)
    {
        return new SelectList(_context.DaggerheartCharacters, "Id", "Name", selectedId);
    }
}
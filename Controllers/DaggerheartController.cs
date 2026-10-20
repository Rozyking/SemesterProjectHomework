using Microsoft.AspNetCore.Mvc;
using DaggerheartProject.Models;
using DaggerheartProject.Data;
using Microsoft.EntityFrameworkCore;

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

    // GET: DaggerheartCharactersScaffold/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var daggerheartCharacter = await _context.DaggerheartCharacters.FindAsync(id);
        if (daggerheartCharacter == null)
        {
            return NotFound();
        }
        return View(daggerheartCharacter);
    }

    // POST: DaggerheartCharactersScaffold/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Class,HitPoints,Evasion")] DaggerheartCharacter daggerheartCharacter)
    {
        if (id != daggerheartCharacter.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(daggerheartCharacter);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DaggerheartCharacterExists(daggerheartCharacter.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(daggerheartCharacter);
    }

    // GET: DaggerheartCharactersScaffold/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var daggerheartCharacter = await _context.DaggerheartCharacters
            .FirstOrDefaultAsync(m => m.Id == id);
        if (daggerheartCharacter == null)
        {
            return NotFound();
        }

        return View(daggerheartCharacter);
    }

    // POST: DaggerheartCharactersScaffold/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var daggerheartCharacter = await _context.DaggerheartCharacters.FindAsync(id);
        if (daggerheartCharacter != null)
        {
            _context.DaggerheartCharacters.Remove(daggerheartCharacter);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DaggerheartCharacterExists(int id)
    {
        return _context.DaggerheartCharacters.Any(e => e.Id == id);
    }
    
}
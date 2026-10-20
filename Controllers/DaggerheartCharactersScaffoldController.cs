using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DaggerheartProject.Data;
using DaggerheartProject.Models;

namespace DaggerheartProject.Controllers
{
    public class DaggerheartCharactersScaffoldController : Controller
    {
        private readonly DaggerheartContext _context;

        public DaggerheartCharactersScaffoldController(DaggerheartContext context)
        {
            _context = context;
        }

        // GET: DaggerheartCharactersScaffold
        public async Task<IActionResult> Index()
        {
            return View(await _context.DaggerheartCharacters.ToListAsync());
        }

        // GET: DaggerheartCharactersScaffold/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: DaggerheartCharactersScaffold/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DaggerheartCharactersScaffold/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Class,HitPoints,Evasion")] DaggerheartCharacter daggerheartCharacter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(daggerheartCharacter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(daggerheartCharacter);
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
}

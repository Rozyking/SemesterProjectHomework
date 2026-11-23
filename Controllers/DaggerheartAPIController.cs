using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DaggerheartProject.Data;
using DaggerheartProject.Models;

namespace DaggerheartProject.Controllers;

// Week 13: same as DaggerheartController but answers in JSON.
[ApiController]
[Route("api/Daggerheart")]
public class DaggerheartApiController : ControllerBase
{
    private readonly DaggerheartContext _context;

    public DaggerheartApiController(DaggerheartContext context)
    {
        _context = context;
    }

    // GET /api/Daggerheart
    [HttpGet]
    public async Task<List<DaggerheartCharacter>> GetAll()
    {
        return await _context.DaggerheartCharacters.ToListAsync();
    }

    // GET /api/Daggerheart/2
    [HttpGet("{id:int}")]
    public async Task<ActionResult<DaggerheartCharacter>> GetOne(int id)
    {
        var character = await _context.DaggerheartCharacters
            .Include(c => c.Attacks)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (character == null)
        {
            return NotFound();
        }

        return character;
    }
}
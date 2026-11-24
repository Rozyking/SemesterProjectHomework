using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DaggerheartProject.Data;
using DaggerheartProject.Models;
using DaggerheartProject.ViewModels;
using DaggerheartProject.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace DaggerheartProject.Controllers;

// Week 13: same as DaggerheartController but answers in JSON.
[ApiController]
[Route("api/Daggerheart")]
[Authorize(Roles = "DungeonMaster")]
public class DaggerheartApiController : ControllerBase
{
    private readonly DaggerheartContext _context;

    public DaggerheartApiController(DaggerheartContext context)
    {
        _context = context;
    }

    // GET /api/Daggerheart
    [AllowAnonymous]
    [HttpGet]
    public async Task<List<CharacterDto>> GetAll()
    {
        var characters = await _context.DaggerheartCharacters
            .Include(a => a.Attacks)
            .ToListAsync();

        return characters.Select(ToDto).ToList();
    }

    // GET /api/Daggerheart/2
    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CharacterDto>> GetOne(int id)
    {
        var character = await _context.DaggerheartCharacters
            .Include(c => c.Attacks)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (character == null)
        {
            return NotFound();
        }

        return ToDto(character);
    }

    // POST /api/Daggerheart
    // [ApiController] has already refused anything that breaks CharacterInput's
    // rules, with a 400, so there is no ModelState check here
    [HttpPost]
    public async Task<ActionResult<CharacterDto>> Create(CharacterInput input)
    {
        var character = new DaggerheartCharacter
        {
            Name = input.Name,
            Class = input.Class,
            HitPoints = input.HitPoints,
            Evasion = input.Evasion,
            LowerDamageThreshold = input.LowerDamageThreshold,
            UpperDamageThreshold = input.UpperDamageThreshold
        };

        _context.DaggerheartCharacters.Add(character);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOne), new { id = character.Id }, ToDto(character));
    }

    // PUT /api/Daggerheart/2
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, CharacterInput input)
    {
        var character = await _context.DaggerheartCharacters.FindAsync(id);
        if (character == null)
        {
            return NotFound();
        }

        character.Name = input.Name;
        character.Class = input.Class;
        character.HitPoints = input.HitPoints;
        character.Evasion = input.Evasion;
        character.LowerDamageThreshold = input.LowerDamageThreshold;
        character.UpperDamageThreshold = input.UpperDamageThreshold;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE /api/Daggerheart/2
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var character = await _context.DaggerheartCharacters.FindAsync(id);
        if (character == null)
        {
            return NotFound();
        }

        _context.DaggerheartCharacters.Remove(character);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private static CharacterDto ToDto(DaggerheartCharacter character) => new CharacterDto
    {
        Id = character.Id,
        Name = character.Name,
        Class = character.Class,
        HitPoints = character.HitPoints,
        Evasion = character.Evasion,
        LowerDamageThreshold = character.LowerDamageThreshold,
        UpperDamageThreshold = character.UpperDamageThreshold,
        Attacks = character.Attacks
            .Select(a => new AttackDto { Name = a.Name, Type = a.Type, DiceRoll = a.DiceRoll,
            Modifier = a.Modifier, Effects = a.Effects})
            .ToList()
    };
}
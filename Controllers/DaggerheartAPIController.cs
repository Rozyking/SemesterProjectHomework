using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DaggerheartProject.Data;
using DaggerheartProject.Models;
using DaggerheartProject.ViewModels;
using DaggerheartProject.Dtos;

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
    public async Task<List<CharacterDto>> GetAll()
    {
        var characters = await _context.DaggerheartCharacters
            .Include(a => a.Attacks)
            .ToListAsync();

        return characters.Select(ToDto).ToList();
    }

    // GET /api/Daggerheart/2
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

    // POST /api/trucks
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
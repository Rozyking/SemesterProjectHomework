using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DaggerheartProject.Models;

public class Attacks
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Each attack has a type (physical or magic)")]
    [StringLength(20, MinimumLength = 5)]
    public string Type { get; set; } = "";

    [Required(ErrorMessage = "Attack must include a type of die (enter as number of faces)")]
    [Range(1, 20)]
    public int DiceRoll { get; set; }

    [Range(1,10)]
    public int? Modifier { get; set; }

    public string? Effects { get; set; } = "";

    [Display(Name = "Character")]
    public int DaggerheartCharacterId { get; set; }

    public DaggerheartCharacter? daggerheartCharacter { get; set; }
}
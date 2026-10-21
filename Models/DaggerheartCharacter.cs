using System.ComponentModel.DataAnnotations;

namespace DaggerheartProject.Models;

public class DaggerheartCharacter
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please include the character's name.")]
    [StringLength(60, MinimumLength = 2)]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Please include the character's class.")]
    [StringLength(60, MinimumLength = 2)]
    public string Class { get; set; } = "";

    [Required(ErrorMessage = "Enter the character's hit point value.")]
    [Range(1, 12)]
    public int HitPoints { get; set; }

    [Required(ErrorMessage = "Enter the character's evasion value.")]
    [Range(1, 30)]
    public int Evasion { get; set; }

    [Required(ErrorMessage = "Enter lower damage threshold for character.")]
    [Range(1, 30)]
    public int LowerDamageThreshold { get; set; }

    [Required(ErrorMessage = "Enter upper damage threshold for character.")]
    [Range(2, 40)]
    public int UpperDamageThreshold { get; set; }
    
}

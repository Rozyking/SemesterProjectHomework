namespace DaggerheartProject.Dtos;

// What the API says about a character. A DTO is a class whose only job is the shape of
// the JSON, so the JSON stops being whatever the table looks like.
public class CharacterDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Class { get; set; } = "";
    public int HitPoints { get; set; }
    public int Evasion { get; set; }
    public int LowerDamageThreshold { get; set; }
    public int UpperDamageThreshold { get; set; }
    public List<AttackDto> Attacks { get; set; } = new();
}
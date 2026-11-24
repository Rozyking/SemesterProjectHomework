namespace DaggerheartProject.Dtos;

// One line of a character's attacks as the API says it. The attack name instead of an
// Attack object, and no way back to the character.
public class AttackDto
{
    public string Name {get; set;} = "";
    public string Type {get; set;} = "";

    public int DiceRoll {get; set;}
    public int? Modifier {get; set;}
    public string? Effects {get; set;} = "";
}
namespace Models;

public static class DaggerheartCharacterData
{
    public static List<DaggerheartCharacter> All { get; } = new()
    {
        new DaggerheartCharacter { Id = 1, Name = "Chug Fligadoo", Class = "Warrior", HitPoints = 6, Evasion = 11},
        new DaggerheartCharacter { Id = 2, Name = "Norman Chesnut", Class = "Druid", HitPoints = 6, Evasion = 10},
        new DaggerheartCharacter { Id = 3, Name = "Ena", Class = "Wizard", HitPoints = 5, Evasion = 11},
        new DaggerheartCharacter { Id = 4, Name = "Rusty Peters", Class = "Rouge", HitPoints = 6, Evasion = 12},
        new DaggerheartCharacter { Id = 5, Name = "Jebadiah Jemsen",  Class = "Seraph", HitPoints = 7, Evasion = 9},
        new DaggerheartCharacter { Id = 6, Name = "Charles Limburger", Class = "Guardian", HitPoints = 7, Evasion = 9},
    };
}

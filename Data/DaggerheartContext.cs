using Microsoft.EntityFrameworkCore;
using DaggerheartProject.Models;

namespace DaggerheartProject.Data;

public class DaggerheartContext : DbContext
{
    
    public DaggerheartContext(DbContextOptions<DaggerheartContext> options) : base(options)
    {

    }

    public DbSet<DaggerheartCharacter> DaggerheartCharacters => Set<DaggerheartCharacter>();
    public DbSet<Attacks> Attacks => Set<Attacks>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DaggerheartCharacter>().HasData(
            new DaggerheartCharacter { Id = 1, Name = "Chug Fligadoo", Class = "Warrior", HitPoints = 6, Evasion = 11, LowerDamageThreshold = 10, UpperDamageThreshold = 17 },
            new DaggerheartCharacter { Id = 2, Name = "Norman Chesnut", Class = "Druid", HitPoints = 6, Evasion = 10, LowerDamageThreshold = 8, UpperDamageThreshold = 15 },
            new DaggerheartCharacter { Id = 3, Name = "Ena", Class = "Wizard", HitPoints = 5, Evasion = 11, LowerDamageThreshold = 7, UpperDamageThreshold = 14 },
            new DaggerheartCharacter { Id = 4, Name = "Rusty Peters", Class = "Rogue", HitPoints = 6, Evasion = 12, LowerDamageThreshold = 19, UpperDamageThreshold = 15  },
            new DaggerheartCharacter { Id = 5, Name = "Jebadiah Jemsen", Class = "Seraph", HitPoints = 7, Evasion = 9, LowerDamageThreshold = 10, UpperDamageThreshold = 16 },
            new DaggerheartCharacter { Id = 6, Name = "Charles Limburger", Class = "Guardian", HitPoints = 7, Evasion = 9, LowerDamageThreshold = 12, UpperDamageThreshold = 19 }
        );

        modelBuilder.Entity<Attacks>().HasData(
            new Attacks {Id = 1, DaggerheartCharacterId = 1, Name = "Sword", Type = "Physical", DiceRoll = 8, Modifier = 1, Effects = ""},
            new Attacks {Id = 2, DaggerheartCharacterId = 3, Name = "Bow", Type = "Physical", DiceRoll = 6, Modifier = 1, Effects = ""},
            new Attacks {Id = 3, DaggerheartCharacterId = 2, Name = "Fireball", Type = "Magic", DiceRoll = 10, Modifier = 2, Effects = "Sets target on fire"},
            new Attacks {Id = 4, DaggerheartCharacterId = 3, Name = "Unarmed", Type = "Physical", DiceRoll = 4, Modifier = 0, Effects = ""},
            new Attacks {Id = 5, DaggerheartCharacterId = 4, Name = "Magic Gauntlets", Type = "Magic", DiceRoll = 10, Modifier = 1, Effects = ""},
            new Attacks {Id = 6, DaggerheartCharacterId = 5, Name = "Dagger", Type = "Physical", DiceRoll = 6, Modifier = 0, Effects = "Can be used as secondary weapon"}
        );
    }
}
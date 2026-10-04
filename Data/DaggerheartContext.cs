using Microsoft.EntityFrameworkCore;
using DaggerheartProject.Models;

namespace DaggerheartProject.Data;

public class DaggerheartContext : DbContext
{
    public DaggerheartContext(DbContextOptions<DaggerheartContext> options) : base(options)
    {
        
    }

    public DbSet<DaggerheartCharacter> DaggerheartCharacters => Set<DaggerheartCharacter>();
}
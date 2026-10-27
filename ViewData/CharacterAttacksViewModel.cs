using DaggerheartProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DaggerheartProject.ViewModels;

public class CharacterAttacksViewModel
{
    public SelectList? Characters { get; set; }
    public Attacks Attack { get; set; } = new();
}
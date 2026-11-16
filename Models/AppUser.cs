using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DaggerheartProject.Models;

public class AppUser : IdentityUser
{
     // What the navbar calls you. A new column on AspNetUsers.
    [StringLength(40)]
    public string PlayerName { get; set; } = "";
}
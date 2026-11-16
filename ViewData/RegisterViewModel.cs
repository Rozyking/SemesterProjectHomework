using System.ComponentModel.DataAnnotations;

namespace DaggerheartProject.ViewData;

// What the registration form posts. It is not the user: the password
// arrives here once, Identity hashes it, and it is never stored.
public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare(nameof(Password), ErrorMessage = "The two passwords don't match.")]
    public string ConfirmPassword { get; set; } = "";
}
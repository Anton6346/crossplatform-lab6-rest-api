using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required, MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required, MaxLength(500)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [RegularExpression(@"^(?=.*\d)(?=.*[A-Z])(?=.*[\W_]).{8,16}$",
        ErrorMessage = "Password must contain digit, symbol, uppercase letter")]
    public string Password { get; set; } = string.Empty;

    [Compare("Password")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required]
    [RegularExpression(@"^\+380\d{9}$")]
    public string Phone { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}

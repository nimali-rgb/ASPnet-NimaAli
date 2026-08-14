using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Email krävs.")]
    [EmailAddress(ErrorMessage = "Ogiltig email.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Lösenord krävs.")]
    [MinLength(6, ErrorMessage = "Lösenord måste vara minst 6 tecken.")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Bekräfta lösenord.")]
    [Compare("Password", ErrorMessage = "Lösenorden matchar inte.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}

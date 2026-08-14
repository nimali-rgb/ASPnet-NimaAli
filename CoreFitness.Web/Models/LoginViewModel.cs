using System.ComponentModel.DataAnnotations;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email krävs.")]
    [EmailAddress(ErrorMessage = "Ogiltig email.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Lösenord krävs.")]
    public string Password { get; set; } = string.Empty;

    public bool RememberMe { get; set; }
}

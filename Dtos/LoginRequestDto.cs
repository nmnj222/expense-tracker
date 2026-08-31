using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Dtos;

public record LoginRequestDto
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
    public required string Username { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
    public required string Password { get; set; }
}

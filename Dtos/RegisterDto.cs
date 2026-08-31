using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Dtos
{
    public record RegisterDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [MinLength(3)]
        public required string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        [EmailAddress]
        public required string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [MinLength(8)]
        public required string Password { get; set; }

    }
}

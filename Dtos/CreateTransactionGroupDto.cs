using ExpenseTracker.Enums;
using ExpenseTracker.Validators;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Dtos
{
    public record CreateTransactionGroupDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Group name is required")]
        public required string Name { get; set; }

        [GreaterThanZero]
        public int MonthlyCap { get; set; }

        [Required]
        [Range(0, 1)]
        public TransactionType TransactionType { get; set; }
    }
}

using ExpenseTracker.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Dtos
{
    public class CreateTransactionGroupDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Group name is required")]
        public required string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int MonthlyCap { get; set; }

        [Required]
        [Range(0, 1)]
        public TransactionType TransactionType { get; set; }
    }
}

using ExpenseTracker.Validators;
namespace ExpenseTracker.Dtos;

public record CreateTransactionDto
{
    [GreaterThanZero]
    public int Amount { get; set; }

    [GreaterThanZero]
    public int TransactionGroupId { get; set; }

    public bool IsScheduled { get; set; }
    public DateTime? ScheduledAt { get; set; }
}

using ExpenseTracker.Validators;
namespace ExpenseTracker.Dtos;

public record CreateScheduledTransactionDto
{
    [GreaterThanZero]
    public int Amount { get; set; }

    [GreaterThanZero]
    public int TransactionGroupId { get; set; }

    [DateNotInThePast]
    public DateTime ScheduledAt { get; set; }

}

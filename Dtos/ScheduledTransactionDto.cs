using ExpenseTracker.Enums;
using ExpenseTracker.Models;

namespace ExpenseTracker.Dtos;

public record ScheduledTransactionDto
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public required TransactionGroupDto TransactionGroup { get; set; }
    public DateTime ScheduledAt { get; set; }
    public ScheduledTransactionStatus Status { get; set; }
}

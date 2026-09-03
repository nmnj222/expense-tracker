using ExpenseTracker.Enums;

namespace ExpenseTracker.Models;

public class ScheduledTransaction
{
    public int Id { get; set; }

    public int Amount { get; set; }

    public required int TransactionGroupId { get; set; }

    public TransactionGroup TransactionGroup { get; set; } = null!;

    public DateTime ScheduledAt { get; set; }

    public ScheduledTransactionStatus Status { get; set; }

    public string? ErrorMessage { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}

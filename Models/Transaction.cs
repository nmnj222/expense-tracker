using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models;

public class Transaction
{
    public int Id { get; set; }

    public int Amount { get; set; }

    public required int TransactionGroupId { get; set; }

    public TransactionGroup TransactionGroup { get; set; } = null!;

    public bool IsScheduled { get; set; }

    public DateTime ScheduledAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }

    public Transaction() { }
}


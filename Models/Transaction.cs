using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models;

public class Transaction
{
    public int Id { get; set; }

    public int Amount { get; set; }

    public int TransactionGroupId { get; set; }

    public required TransactionGroup TransactionGroup { get; set; }

    public bool IsScheduled { get; set; }

    public DateTime ScheduledAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }
}



namespace ExpenseTracker.Models;

public class Transaction
{
    public int Id { get; set; }

    public int Amount { get; set; }

    public required int TransactionGroupId { get; set; }

    public TransactionGroup TransactionGroup { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }

}


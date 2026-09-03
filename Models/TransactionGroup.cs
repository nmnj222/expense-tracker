using System.ComponentModel.DataAnnotations.Schema;
using ExpenseTracker.Enums;

namespace ExpenseTracker.Models;

public class TransactionGroup
{
    public int Id { get; set; }

    [Column(TypeName = "varchar(200)")]
    public required string Name { get; set; }

    public int UserId { get; set; }

    public User User { get; set; } = null!;

    public int MonthlyCap { get; set; }

    public TransactionType TransactionType { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }

    public List<Transaction> Transactions { get; set; } = new();

    public TransactionGroup() { }
}

using ExpenseTracker.Enums;
using ExpenseTracker.Models;

namespace ExpenseTracker.Dtos;

public record TransactionGroupDetailsDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int MonthlyCap { get; set; }
    public TransactionType TransactionType { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<Transaction> Transactions { get; set; } = new();
}

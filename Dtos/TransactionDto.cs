namespace ExpenseTracker.Dtos;

public record TransactionDto
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public required TransactionGroupDto TransactionGroup { get; set; }
}

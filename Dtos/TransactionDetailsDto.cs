namespace ExpenseTracker.Dtos;

public record TransactionDetailsDto
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public required TransactionGroupDto TransactionGroup { get; set; }
    public bool IsScheduled { get; set; }
    public DateTime ScheduledAt { get; set; }
    public DateTime CreatedAt { get; set; }
}

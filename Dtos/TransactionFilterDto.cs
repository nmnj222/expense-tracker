using ExpenseTracker.Enums;

namespace ExpenseTracker.Dtos;

public record TransactionFilterDto
{
    public int? TransactionGroupId { get; set; }
    public TransactionType? TransactionType { get; set; }
    public string? SortOrder { get; set; } = string.Empty;
    public int? Page { get; set; } = 1;
    public int? PageSize { get; set; } = 5;

}

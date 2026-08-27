using ExpenseTracker.Enums;

namespace ExpenseTracker.Dtos
{
    public record TransactionGroupDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}

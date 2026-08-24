using ExpenseTracker.Enums;

namespace ExpenseTracker.Dtos
{
    public class CreateTransactionGroupDto
    {
        public string Name { get; set; }
        public int MonthlyCap { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}

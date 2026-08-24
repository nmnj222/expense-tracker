using ExpenseTracker.Enums;
using ExpenseTracker.Models;

namespace ExpenseTracker.Dtos
{
    public class TransactionGroupDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MonthlyCap { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //change return type to DTO when made
        public List<Transaction> Transactions { get; set; } = new();
    }
}

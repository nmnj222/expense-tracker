using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    [Table("transaction_group")]
    public class TransactionGroup
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(200)")]
        public required string Name { get; set; }

        public int UserId { get; set; }

        public required User User { get; set; }

        public int MonthlyCap { get; set; }

        public TransactionType TransactionType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Reminder> Reminders { get; set; } = new List<Reminder>();
    }
}

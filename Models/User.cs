using System.ComponentModel.DataAnnotations.Schema;

namespace expense_tracker.Models
{
    [Table("users")]
    public class User
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string? LastName { get; set;  }

        [Column(TypeName = "varchar(200)")]
        public required string Username {  get; set; }

        [Column(TypeName = "varchar(200)")]
        public required string Password { get; set; }

        [Column(TypeName = "varchar(200)")]
        public required string Email { get; set;  }
        public bool IsPremium { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public DateTime LastLoginAt { get; set; }

        public ICollection<TransactionGroup> TransactionGroups { get; set; } = new List<TransactionGroup>();
        public ICollection<Reminder> Reminders { get; set; } = new List<Reminder>();

        public ICollection<SavingsPlan> SavingPlans { get; set; } = new List<SavingsPlan>();

    }
}

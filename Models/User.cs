using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    [Table("user")]
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

        public List<TransactionGroup> TransactionGroups { get; set; } = new();

        public List<SavingsPlan> SavingPlans { get; set; } = new();

    }
}

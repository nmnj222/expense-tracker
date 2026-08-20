using System.ComponentModel.DataAnnotations.Schema;
using ExpenseTracker.Enums;

namespace ExpenseTracker.Models;

public class SavingsPlan
{
    public int Id { get; set; }

    [Column(TypeName = "varchar(200)")]
    public required string Name { get; set; }

    public int UserId { get; set; }

    public required User User { get; set; }

    public int TargetAmount { get; set; }

    public DateTime TargetDate { get; set; }

    public int SavedAmount { get; set; }

    public DateTime StartDate { get; set; }

    public SavingsPlanType Type { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; }
}

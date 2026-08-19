using System.ComponentModel.DataAnnotations.Schema;
using ExpenseTracker.Enums;

namespace ExpenseTracker.Models;

[Table("reminder")]
public class Reminder
{
    public int Id { get; set; }

    public ReminderFrequency ReminderFrequency { get; set; }

    public int TransactionGroupId { get; set; }

    public required TransactionGroup TransactionGroup { get; set; }

    public bool IsEnabled { get; set; }

    public int AmountThreshold { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }

    public DateTime LastSentAt { get; set; }

    public DateTime NextSendAt { get; set; }

}

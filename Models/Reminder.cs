using ExpenseTracker.Enums;

namespace ExpenseTracker.Models;

public class Reminder
{
    public int Id { get; set; }

    public ReminderFrequency ReminderFrequency { get; set; }

    public int UserId { get; set; }

    public User User { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; }

    public DateTime LastSentAt { get; set; }

    public DateTime NextSendAt { get; set; }

}

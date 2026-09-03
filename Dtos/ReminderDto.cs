using ExpenseTracker.Enums;

namespace ExpenseTracker.Dtos;

public record ReminderDto
{

    public int Id { get; set; }
    public ReminderFrequency ReminderFrequency { get; set; }
    public bool IsEnabled { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime NextSendAt { get; set; }

}

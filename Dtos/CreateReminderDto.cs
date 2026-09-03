using ExpenseTracker.Enums;

namespace ExpenseTracker.Dtos;

public class CreateReminderDto
{
    public ReminderFrequency ReminderFrequency { get; set; }
}

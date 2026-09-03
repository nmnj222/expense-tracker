using ExpenseTracker.Dtos;
using ExpenseTracker.Models;

namespace ExpenseTracker.Mappers;

public static class ReminderMapper
{
    public static ReminderDto ToDto(Reminder reminder) =>
        new ReminderDto
        {
            Id = reminder.Id,
            ReminderFrequency = reminder.ReminderFrequency,
            IsEnabled = reminder.IsEnabled,
            CreatedAt = reminder.CreatedAt,
            NextSendAt = reminder.NextSendAt
        };
}

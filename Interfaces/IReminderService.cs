using ExpenseTracker.Common.Results;
using ExpenseTracker.Dtos;

namespace ExpenseTracker.Interfaces;

public interface IReminderService
{
    Task<Result<List<ReminderDto>>> GetUserReminders(int userId);
    Task<Result<ReminderDto>> CreateUserReminder(int userId, CreateReminderDto createDto);
    Task<Result<bool>> DeleteUserReminder(int userId, int reminderId);
}

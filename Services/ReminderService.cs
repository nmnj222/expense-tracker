using ExpenseTracker.Common.Results;
using ExpenseTracker.Common.Results.Errors;
using ExpenseTracker.Data;
using ExpenseTracker.Dtos;
using ExpenseTracker.Interfaces;
using ExpenseTracker.Mappers;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Services;

public class ReminderService(ApplicationDbContext _context) : IReminderService
{
    public async Task<Result<ReminderDto>> CreateUserReminder(int userId, CreateReminderDto createDto)
    {
        DateTime now = DateTime.UtcNow;

        Reminder reminder = new Reminder
        {
            ReminderFrequency = createDto.ReminderFrequency,
            IsEnabled = true,
            CreatedAt = now,
            UpdatedAt = now,
            NextSendAt = createDto.ReminderFrequency == Enums.ReminderFrequency.Monthly ? now.AddMonths(1) : now.AddDays(7),
            UserId = userId
        };

        _context.Reminders.Add(reminder);
        await _context.SaveChangesAsync();

        return Result<ReminderDto>.Success(ReminderMapper.ToDto(reminder));
    }

    public async Task<Result<bool>> DeleteUserReminder(int userId, int reminderId)
    {
        var reminder = await _context.Reminders
            .FirstOrDefaultAsync(r => r.Id == reminderId && r.UserId == userId);

        if (reminder is null)
        {
            return Result<bool>.Failure(ReminderErrors.NotFound(reminderId));
        }

        _context.Reminders.Remove(reminder);
        await _context.SaveChangesAsync();

        return Result<bool>.Success(true);

    }

    public async Task<Result<List<ReminderDto>>> GetUserReminders(int userId)
    {
        var remindersRaw = await _context.Reminders
            .Where(r => r.UserId == userId)
            .ToListAsync();

        var reminders = remindersRaw.Select(r => ReminderMapper.ToDto(r)).ToList();

        return Result<List<ReminderDto>>.Success(reminders);
    }
}

using Coravel.Invocable;
using ExpenseTracker.Data;
using ExpenseTracker.Models;
using ExpenseTracker.Services;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Jobs;

public class ProcessReminders(ApplicationDbContext _context, ILogger<ProcessReminders> _logger) : IInvocable
{
    public async Task Invoke()
    {
        _logger.LogInformation("Running process reminders task");
        DateTime now = DateTime.UtcNow;

        var activeReminders = await _context.Reminders
            .Where(r => r.NextSendAt <= now)
            .ToListAsync();

        if (activeReminders.Count == 0)
        {
            return;
        }

        foreach (var reminder in activeReminders)
        {
            DateTime dateFrom = reminder.LastSentAt != DateTime.MinValue ? reminder.LastSentAt : reminder.CreatedAt;
            DateTime dateTo = reminder.NextSendAt;

            int totalSpent = await CalculateUserExpenses(dateFrom, dateTo, reminder.UserId);

            string message = $"User with id: {reminder.UserId}, spent a total of {totalSpent} in the period: {dateFrom.Date} - {dateTo.Date}";

            Notification notification = new Notification
            {
                UserId = reminder.UserId,
                ReminderId = reminder.Id,
                Message = message,
                CreatedAt = now
            };

            _context.ReminderNotifications.Add(notification);

            reminder.LastSentAt = now;
            reminder.NextSendAt = reminder.ReminderFrequency == Enums.ReminderFrequency.Monthly ? dateTo.AddMonths(1) : dateTo.AddDays(7);
            _logger.LogInformation($"Finished processing reminder with id: {reminder.Id}");

        }

        await _context.SaveChangesAsync();
        _logger.LogInformation($"Reminder changes persisted");
    }

    private async Task<int> CalculateUserExpenses(DateTime dateFrom, DateTime dateTo, int userId)
    {
        return await _context.Transactions
            .Where(t => t.CreatedAt >= dateFrom && t.CreatedAt <= dateTo && t.TransactionGroup.UserId == userId && t.TransactionGroup.TransactionType == Enums.TransactionType.Expense)
            .SumAsync(t => t.Amount);
    }
}

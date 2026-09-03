using Coravel.Invocable;
using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Jobs;

public class ProcessScheduledTransactions(ApplicationDbContext _context, ILogger<ProcessScheduledTransactions> _logger) : IInvocable
{
    public async Task Invoke()
    {
        _logger.LogInformation("Initiated processing scheduled transactions");
        DateTime now = DateTime.UtcNow;

        var scheduledTransactions = await _context.ScheduledTransactions
            .Where(st => st.ScheduledAt <= now && st.Status == Enums.ScheduledTransactionStatus.Scheduled)
            .ToListAsync();

        if (scheduledTransactions.Count == 0)
        {
            return;
        }

        foreach (var scheduled in scheduledTransactions)
        {


            Transaction transaction = new Transaction
            {
                Amount = scheduled.Amount,
                TransactionGroupId = scheduled.TransactionGroupId,
                CreatedAt = now
            };

            _context.Add(transaction);

            scheduled.Status = Enums.ScheduledTransactionStatus.Executed;

            await _context.SaveChangesAsync();
            _logger.LogInformation($"Succesfully processed scheduled transaction with id: {scheduled.Id}");
        }
    }
}

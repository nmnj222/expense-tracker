using Coravel.Invocable;
using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Jobs;

public class ProcessScheduledTransactions(ApplicationDbContext _context, ILogger<ProcessScheduledTransactions> _logger) : IInvocable
{
    public async Task Invoke()
    {
        _logger.LogInformation("Logger running.");
        DateTime now = DateTime.UtcNow;

        var scheduledTransactions = await _context.ScheduledTransactions
            .Where(st => st.ScheduledAt <= now  && st.Status == Enums.ScheduledTransactionStatus.Scheduled)
            .ToListAsync();

        if (scheduledTransactions.Count == 0) return;

        foreach (var scheduled in scheduledTransactions)
        {
            scheduled.Status = Enums.ScheduledTransactionStatus.InProgress;
            await _context.SaveChangesAsync();

            using var dbTransaction = await _context.Database.BeginTransactionAsync();

            try
            {

                Transaction transaction = new Transaction
                {
                    Amount = scheduled.Amount,
                    TransactionGroupId = scheduled.TransactionGroupId,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Add(transaction);

                scheduled.Status = Enums.ScheduledTransactionStatus.Executed;

                await _context.SaveChangesAsync();
                await dbTransaction.CommitAsync();

            }
            catch (Exception e)
            {
                await dbTransaction.RollbackAsync();
                _logger.LogError(e, "Failed to execute scheduled transaction {Id}", scheduled.Id);

                scheduled.Status = Enums.ScheduledTransactionStatus.Failed;
                await _context.SaveChangesAsync();
            }
        }
    }
}

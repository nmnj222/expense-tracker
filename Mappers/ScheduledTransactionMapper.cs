using ExpenseTracker.Dtos;
using ExpenseTracker.Models;

namespace ExpenseTracker.Mappers;

public static class ScheduledTransactionMapper
{
    public static ScheduledTransactionDto ToDto(ScheduledTransaction transaction) =>
        new ScheduledTransactionDto
        {
            Amount = transaction.Amount,
            TransactionGroup = transaction.TransactionGroup,
            ScheduledAt = transaction.ScheduledAt,
            Status = transaction.Status
        };
}

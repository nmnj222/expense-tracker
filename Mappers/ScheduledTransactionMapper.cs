using ExpenseTracker.Dtos;
using ExpenseTracker.Models;

namespace ExpenseTracker.Mappers;

public static class ScheduledTransactionMapper
{
    public static ScheduledTransactionDto ToDto(ScheduledTransaction transaction) =>
        new ScheduledTransactionDto
        {
            Id = transaction.Id,
            Amount = transaction.Amount,
            TransactionGroup = TransactionGroupMapper.ToDto(transaction.TransactionGroup),
            ScheduledAt = transaction.ScheduledAt,
            Status = transaction.Status
        };
}

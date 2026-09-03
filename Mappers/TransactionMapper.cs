using ExpenseTracker.Dtos;
using ExpenseTracker.Models;

namespace ExpenseTracker.Mappers;

public static class TransactionMapper
{
    public static TransactionDto ToDto(Transaction transaction) =>
        new TransactionDto
        {
            Id = transaction.Id,
            Amount = transaction.Amount,
            TransactionGroup = TransactionGroupMapper.ToDto(transaction.TransactionGroup),
            CreatedAt = transaction.CreatedAt
        };

    public static TransactionDetailsDto ToDetailsDto(Transaction transaction) =>
        new TransactionDetailsDto
        {
            Id = transaction.Id,
            Amount = transaction.Amount,
            TransactionGroup = TransactionGroupMapper.ToDto(transaction.TransactionGroup),
            CreatedAt = transaction.CreatedAt,
        };
}

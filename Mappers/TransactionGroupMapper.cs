using ExpenseTracker.Dtos;
using ExpenseTracker.Models;

namespace ExpenseTracker.Mappers
{
    public class TransactionGroupMapper
    {

        public static TransactionGroupDto ToDto(TransactionGroup transactionGroup) =>
        new TransactionGroupDto
        {
            Id = transactionGroup.Id,
            Name = transactionGroup.Name,
            TransactionType = transactionGroup.TransactionType
        };

        public static TransactionGroupDetailsDto toDetailsDto(TransactionGroup transactionGroup) =>
            new TransactionGroupDetailsDto
            {
                Id = transactionGroup.Id,
                Name = transactionGroup.Name,
                MonthlyCap = transactionGroup.MonthlyCap,
                TransactionType = transactionGroup.TransactionType,
                CreatedAt = transactionGroup.CreatedAt,
                UpdatedAt = transactionGroup.UpdatedAt,
                Transactions = transactionGroup.Transactions.ToList()
            };
    }
}

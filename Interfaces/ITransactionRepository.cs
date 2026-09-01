using ExpenseTracker.Dtos;
using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces;

public interface ITransactionRepository
{

    Task<(List<Transaction> Transactions, int TotalCount, int PageSize, int Page)> GetUserTransactions(
    int userId,
    TransactionFilterDto filterDto);
}

using ExpenseTracker.Common.Results;
using ExpenseTracker.Dtos;
using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces;

public interface ITransactionRepository
{

    Task<PagedResult<Transaction>> GetUserTransactions(int userId, TransactionFilterDto filterDto);
}

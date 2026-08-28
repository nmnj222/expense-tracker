using ExpenseTracker.Common.Results;
using ExpenseTracker.Dtos;

namespace ExpenseTracker.Interfaces;

public interface ITransactionService
{
    Task<Result<List<TransactionDto>>> GetUserTransactions(int userId);
    Task<Result<TransactionDetailsDto>> GetUserTransactionDetails(int userId, int transactionId);
    Task<Result<bool>> DeleteUserTransaction(int userId, int transactionId);
    Task<Result<TransactionDto>> CreateUserTransaction(int userId, CreateTransactionDto createTransactionDto);
}


using ExpenseTracker.Common.Results;
using ExpenseTracker.Dtos;

namespace ExpenseTracker.Interfaces;

public interface ITransactionService
{
    Task<Result<PagedResult<TransactionDto>>> GetUserTransactions(int userId, TransactionFilterDto filterDto);
    Task<Result<TransactionDetailsDto>> GetUserTransactionDetails(int userId, int transactionId);
    Task<Result<bool>> DeleteUserTransaction(int userId, int transactionId);
    Task<Result<TransactionDto>> CreateUserTransaction(int userId, CreateTransactionDto createTransactionDto);
    Task<Result<List<ScheduledTransactionDto>>> GetUserScheduledTransactions(int userId);
    Task<Result<ScheduledTransactionDto>> CreateUserScheduledTransaction(int userId, CreateScheduledTransactionDto createScheduledTransactionDto);
    Task<Result<bool>> DeleteUserScheduledTransaction(int userId, int scheduledTransactionId);

}


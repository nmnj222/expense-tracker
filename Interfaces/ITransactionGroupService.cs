using ExpenseTracker.Common.Results;
using ExpenseTracker.Dtos;

namespace ExpenseTracker.Interfaces;

public interface ITransactionGroupService
{
    Task<Result<List<TransactionGroupDto>>> GetUserTransactionGroups(int userId);
    Task<Result<TransactionGroupDetailsDto>> GetUserTransactionGroupDetails(int userId, int transactionGroupId);
    Task<Result<TransactionGroupDto>> CreateTransactionGroup(int userId, CreateTransactionGroupDto createDto);
    Task<Result<bool>> DeleteTransactionGroup(int userId, int transactionGroupId);
}

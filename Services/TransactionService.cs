using ExpenseTracker.Common.Results;
using ExpenseTracker.Common.Results.Errors;
using ExpenseTracker.Data;
using ExpenseTracker.Dtos;
using ExpenseTracker.Interfaces;
using ExpenseTracker.Mappers;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Services;

public class TransactionService(ApplicationDbContext _context, ITransactionRepository _transactionRepository) : ITransactionService
{
    public async Task<Result<PagedResult<TransactionDto>>> GetUserTransactions(int userId, TransactionFilterDto filterDto)
    {
        (List<Transaction> Transactions, int TotalCount, int PageSize, int Page) pagedUserTransactions = await _transactionRepository.GetUserTransactions(userId, filterDto);

        List<TransactionDto> transactions = pagedUserTransactions.Transactions.Select(t => TransactionMapper.ToDto(t)).ToList();

        return Result<PagedResult<TransactionDto>>.Success(new PagedResult<TransactionDto>(transactions, pagedUserTransactions.TotalCount, pagedUserTransactions.PageSize, pagedUserTransactions.Page));
    }
    public async Task<Result<TransactionDetailsDto>> GetUserTransactionDetails(int userId, int transactionId)
    {
        var transactionResponse = await _context.Transactions
            .Where(t => t.Id == transactionId && t.TransactionGroup.UserId == userId)
            .FirstOrDefaultAsync();

        if (transactionResponse == null)
        {
            return Result<TransactionDetailsDto>.Failure(TransactionErrors.NotFound(transactionId));
        }

        return Result<TransactionDetailsDto>.Success(TransactionMapper.ToDetailsDto(transactionResponse));
    }
    public async Task<Result<bool>> DeleteUserTransaction(int userId, int transactionId)
    {
        var transactionResponse = await _context.Transactions
            .FirstOrDefaultAsync(t => t.Id == transactionId && t.TransactionGroup.UserId == userId);

        if (transactionResponse == null)
        {
            return Result<bool>.Failure(TransactionErrors.NotFound(transactionId));
        }

        _context.Transactions.Remove(transactionResponse);
        await _context.SaveChangesAsync();

        return Result<bool>.Success(true);
    }

    public async Task<Result<TransactionDto>> CreateUserTransaction(int userId, CreateTransactionDto createDto)
    {
        var transactionGroup = await _context.TransactionGroups
            .FirstOrDefaultAsync(tg => tg.Id == createDto.TransactionGroupId && tg.UserId == userId);

        if (transactionGroup is null)
        {
            return Result<TransactionDto>.Failure(TransactionGroupErrors.NotFound());
        }

        Transaction transaction = new Transaction
        {
            Amount = createDto.Amount,
            TransactionGroupId = createDto.TransactionGroupId,
            TransactionGroup = transactionGroup,
            CreatedAt = DateTime.UtcNow
        };

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        return Result<TransactionDto>.Success(TransactionMapper.ToDto(transaction));
    }

    public async Task<Result<ScheduledTransactionDto>> CreateUserScheduledTransaction(int userId, CreateScheduledTransactionDto createScheduledDto)
    {
        var transactionGroup = await _context.TransactionGroups
            .FirstOrDefaultAsync(tg => tg.Id == createScheduledDto.TransactionGroupId && tg.UserId == userId);

        if (transactionGroup is null)
        {
            return Result<ScheduledTransactionDto>.Failure(TransactionGroupErrors.NotFound());
        }

        ScheduledTransaction scheduledTransaction = new ScheduledTransaction
        {
            Amount = createScheduledDto.Amount,
            TransactionGroupId = createScheduledDto.TransactionGroupId,
            TransactionGroup = transactionGroup,
            ScheduledAt = createScheduledDto.ScheduledAt,
            Status = Enums.ScheduledTransactionStatus.Scheduled
        };

        _context.ScheduledTransactions.Add(scheduledTransaction);
        await _context.SaveChangesAsync();

        return Result<ScheduledTransactionDto>.Success(ScheduledTransactionMapper.ToDto(scheduledTransaction));
    }

    public async Task<Result<List<ScheduledTransactionDto>>> GetUserScheduledTransactions(int userId)
    {
        var scheduledTransactionsResponse = await _context.ScheduledTransactions
            .Include(st => st.TransactionGroup)
            .Where(st => st.TransactionGroup.UserId == userId)
            .ToListAsync();

        var scheduledTransactions = scheduledTransactionsResponse.Select(st => ScheduledTransactionMapper.ToDto(st)).ToList();

        return Result<List<ScheduledTransactionDto>>.Success(scheduledTransactions);

    }

    public async Task<Result<bool>> DeleteUserScheduledTransaction(int userId, int scheduledTransactionId)
    {
        var scheduledTransaction = await _context.ScheduledTransactions
            .FirstOrDefaultAsync(st => st.Id == scheduledTransactionId && st.TransactionGroup.UserId == userId);

        if (scheduledTransaction == null)
        {
            return Result<bool>.Failure(TransactionErrors.NotFound(scheduledTransactionId));
        }

        _context.ScheduledTransactions.Remove(scheduledTransaction);
        await _context.SaveChangesAsync();

        return Result<bool>.Success(true);
    }

}

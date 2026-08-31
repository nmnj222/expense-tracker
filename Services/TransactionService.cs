using ExpenseTracker.Common.Results;
using ExpenseTracker.Common.Results.Errors;
using ExpenseTracker.Data;
using ExpenseTracker.Dtos;
using ExpenseTracker.Interfaces;
using ExpenseTracker.Mappers;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Services;

public class TransactionService(ApplicationDbContext _context) : ITransactionService
{
    public async Task<Result<List<TransactionDto>>> GetUserTransactions(int userId)
    {
        var transactionsResponse = await _context.Transactions
             .Include(t => t.TransactionGroup)
             .Where(t => t.TransactionGroup.UserId == userId)
             .ToListAsync();

        var transactions = transactionsResponse.Select(t => TransactionMapper.ToDto(t)).ToList();

        return Result<List<TransactionDto>>.Success(transactions);
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
            TransactionGroup = transactionGroup
        };

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        return Result<TransactionDto>.Success(TransactionMapper.ToDto(transaction));
    }
}

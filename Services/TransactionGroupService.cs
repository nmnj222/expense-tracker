using ExpenseTracker.Common.Results;
using ExpenseTracker.Common.Results.Errors;
using ExpenseTracker.Data;
using ExpenseTracker.Dtos;
using ExpenseTracker.Interfaces;
using ExpenseTracker.Mappers;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Services;

public class TransactionGroupService(ApplicationDbContext _context) : ITransactionGroupService
{

    public async Task<Result<List<TransactionGroupDto>>> GetUserTransactionGroups(int userId)
    {
        var transactionGroupsRaw = await _context.TransactionGroups
            .Where(t => t.UserId == userId)
            .ToListAsync();

        var transactionGroups = transactionGroupsRaw.Select(t => TransactionGroupMapper.ToDto(t))
        .ToList();

        return Result<List<TransactionGroupDto>>.Success(transactionGroups);
    }

    public async Task<Result<TransactionGroupDetailsDto>> GetUserTransactionGroupDetails(int userId, int transactionGroupId)
    {
        var transactionGroup = await _context.TransactionGroups
            .Where(t => t.UserId == userId && t.Id == transactionGroupId)
            .FirstOrDefaultAsync();

        if (transactionGroup is null)
        {
            return Result<TransactionGroupDetailsDto>.Failure(TransactionGroupErrors.NotFound(transactionGroupId));
        }

        return Result<TransactionGroupDetailsDto>.Success(TransactionGroupMapper.toDetailsDto(transactionGroup));
    }

    public async Task<Result<TransactionGroupDto>> CreateTransactionGroup(int userId, CreateTransactionGroupDto createDto)
    {
        TransactionGroup transactionGroup = new TransactionGroup
        {
            Name = createDto.Name,
            MonthlyCap = createDto.MonthlyCap,
            TransactionType = createDto.TransactionType,
            UserId = userId
        };

        _context.TransactionGroups.Add(transactionGroup);
        await _context.SaveChangesAsync();

        return Result<TransactionGroupDto>.Success(TransactionGroupMapper.ToDto(transactionGroup));
    }
    public async Task<Result<bool>> DeleteTransactionGroup(int userId, int transactionGroupId)
    {
        var transactionGroup = await _context.TransactionGroups
            .FirstOrDefaultAsync(t => t.UserId == userId && t.Id == transactionGroupId);

        if (transactionGroup is null)
        {
            return Result<bool>.Failure(TransactionGroupErrors.NotFound(transactionGroupId));
        }

        _context.TransactionGroups.Remove(transactionGroup);

        await _context.SaveChangesAsync();

        return Result<bool>.Success(true);
    }
}

using ExpenseTracker.Data;
using ExpenseTracker.Dtos;
using ExpenseTracker.Mappers;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Services;

public class TransactionGroupService(ApplicationDbContext _context)
{

    public async Task<List<TransactionGroupDto>> GetUserTransactionGroups(int userId)
    {
        var transactionGroups = await _context.TransactionGroups
            .Where(t => t.UserId == userId)
            .ToListAsync();



        return transactionGroups.Select(t => TransactionGroupMapper.ToDto(t))
        .ToList();
    }

    public async Task<TransactionGroupDetailsDto?> GetUserTransactionGroupDetails(int userId, int transactionGroupId)
    {
        var transactionGroup = await _context.TransactionGroups
            .Where(t => t.UserId == userId && t.Id == transactionGroupId)
            .FirstOrDefaultAsync();

        if (transactionGroup is null)
        {
            return null;
        }

        return TransactionGroupMapper.toDetailsDto(transactionGroup);
    }

    public async Task<TransactionGroupDto> CreateTransactionGroup(int userId, CreateTransactionGroupDto createDto)
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

        return TransactionGroupMapper.ToDto(transactionGroup);
    }

    public async Task<bool> DeleteTransactionGroup(int userId, int transactionGroupId)
    {
        var transactionGroup = await _context.TransactionGroups
            .FirstOrDefaultAsync(t => t.UserId == userId && t.Id == transactionGroupId);

        if (transactionGroup is null)
        {
            return false;
        }

        _context.TransactionGroups.Remove(transactionGroup);

        await _context.SaveChangesAsync();

        return true;
    }
}

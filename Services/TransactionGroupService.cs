using ExpenseTracker.Data;
using ExpenseTracker.Dtos;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Services;

public class TransactionGroupService
{
    private readonly ApplicationDbContext _context;

    public TransactionGroupService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TransactionGroupDto>> GetUserTransactionGroups(int userId)
    {
        var transactionGroups = await _context.TransactionGroups
            .Where(t => t.UserId == userId)
            .Select(t => TransactionGroupToDto(t))
            .ToListAsync();

        return transactionGroups;
    }

    public async Task<TransactionGroupDetailsDto?> GetUserTransactionGroupDetails(int userId, int transactionGroupId)
    {
        return await _context.TransactionGroups
            .Where(t => t.UserId == userId && t.Id == transactionGroupId)
            .Select(t => new TransactionGroupDetailsDto
            {
                Id = t.Id,
                Name = t.Name,
                MonthlyCap = t.MonthlyCap,
                TransactionType = t.TransactionType,
                CreatedAt = t.CreatedAt,
                UpdatedAt = t.UpdatedAt,
                Transactions = t.Transactions.ToList()
            })
            .FirstOrDefaultAsync();
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

        return TransactionGroupToDto(transactionGroup);
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

    private static TransactionGroupDto TransactionGroupToDto(TransactionGroup transactionGroup) =>
        new TransactionGroupDto
        {
            Id = transactionGroup.Id,
            Name = transactionGroup.Name,
            TransactionType = transactionGroup.TransactionType
        };

}

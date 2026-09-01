using ExpenseTracker.Data;
using ExpenseTracker.Dtos;
using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Repositories;

public class TransactionRepository(ApplicationDbContext _context) : ITransactionRepository
{
    public async Task<(List<Transaction> Transactions, int TotalCount, int PageSize, int Page)> GetUserTransactions(
          int userId,
          TransactionFilterDto filterDto)
    {
        var query = _context.Transactions
            .Include(t => t.TransactionGroup)
            .Where(t => t.TransactionGroup.UserId == userId);

        if (filterDto.TransactionGroupId is not null)
        {
            query = query.Where(t =>
                t.TransactionGroup.Id == filterDto.TransactionGroupId);
        }

        if (filterDto.TransactionType is not null)
        {
            query = query.Where(t =>
                t.TransactionGroup.TransactionType == filterDto.TransactionType);
        }

        query = filterDto.SortOrder?.ToLower() switch
        {
            "asc" => query.OrderBy(t => t.CreatedAt),
            _ => query.OrderByDescending(t => t.CreatedAt)
        };

        var totalCount = await query.CountAsync();

        int page = Math.Max(
            filterDto.Page.GetValueOrDefault(1),
            1);

        int pageSize = Math.Clamp(
            filterDto.PageSize.GetValueOrDefault(5),
            1,
            100);

        var transactions = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (transactions, totalCount, pageSize, page);
    }
}

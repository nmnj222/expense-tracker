using ExpenseTracker.Dtos;

namespace ExpenseTracker.Common.Results;

public sealed class PagedResult<T>
{
    public PagedResult(List<TransactionDto> items, int totalCount, int pageSize, int page)
    {
        Items = items;
        TotalCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        PageSize = pageSize;
        Page = page;
    }

    public List<TransactionDto> Items { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int Page { get; set; }
}

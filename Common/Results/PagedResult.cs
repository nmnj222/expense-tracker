using ExpenseTracker.Dtos;

namespace ExpenseTracker.Common.Results;

public sealed class PagedResult<T>
{
    public PagedResult(List<T> items, int pageSize, int page, bool hasNextPage)
    {
        Items = items;
        PageSize = pageSize;
        Page = page;
        HasNextPage = hasNextPage;
    }

    public List<T> Items { get; set; }
    public int PageSize { get; set; }
    public int Page { get; set; }
    public bool HasNextPage { get; set; }
}

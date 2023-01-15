namespace PlatformBase.Core.Concrete;

public class PagedList<T> : List<T>
{
    public int PageIndex { get; private set; }

    public int PageSize { get; private set; }

    public int TotalCount { get; private set; }

    public int TotalPages { get; private set; }

    public bool HasPreviousPage => PageIndex > 1;

    public bool HasNextPage => PageIndex + 1 <= TotalPages;

    public PagedList(IEnumerable<T> items, int totalCount, PagerInput pagerInput)
    {
        PageSize = pagerInput.PageSize;
        PageIndex = pagerInput.PageIndex;
        TotalCount = totalCount;
        TotalPages = TotalCount / PageSize;
        if (TotalCount % PageSize > 0)
        {
            TotalPages++;
        }

        if (items != null)
        {
            AddRange(items);
        }
    }
}
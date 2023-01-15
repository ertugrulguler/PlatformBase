namespace PlatformBase.Core.Concrete;

public class PagerInput
{
    public int PageIndex { get; set; }

    public int PageSize { get; set; }

    public PagerInput(int pageIndex, int pageSize)
    {
        if (pageIndex == 0)
        {
            pageIndex = 1;
        }

        if (pageSize == 0)
        {
            pageSize = 10;
        }

        PageIndex = pageIndex;
        PageSize = pageSize;
    }
}
namespace Dot_Net_WebApi.Domain
{
    public class PagedResult<T>
    {
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public List<T> Items { get; set; }

        public PagedResult(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalItems = count;
            PageNumber = pageNumber;
            PageSize = pageSize;
            Items = items;
        }
    }

}

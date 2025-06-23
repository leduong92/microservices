namespace Microservices.Shared
{
    public class PagedResult<T>
    {
        public List<T>? Items { get; set; }
        public int TotalRecords { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageCout => (int)Math.Ceiling((double)TotalRecords / PageSize);
    }
}

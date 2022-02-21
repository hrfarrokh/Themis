namespace Themis.Application
{
    public class ListResponse<TDto> where TDto : class
    {
        public ListResponse(IEnumerable<TDto> items,
                            int? totalCount = null,
                            Guid? cursor = null)
        {
            Items = items;
            TotalCount = totalCount;
            Cursor = cursor;
        }

        public IEnumerable<TDto> Items { get; set; }
        public int? TotalCount { get; set; }
        public Guid? Cursor { get; set; }
    }
}

namespace Themis.Application.Contracts
{
    public abstract class ListQuery
    {
        public bool TotalCount { get; set; }
        public Guid? Cursor { get; set; }
        public int Take { get; set; } = 20;
    }
}

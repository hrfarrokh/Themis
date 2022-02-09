using Themis.Core.Models;

namespace Themis.Domain
{
    public class OrderId : Uuid<OrderId>
    {
        public OrderId() { }
        public OrderId(Guid value) : base(value) { }
        public new static OrderId Parse(string value)
            => new(Guid.Parse(value));
    }
}

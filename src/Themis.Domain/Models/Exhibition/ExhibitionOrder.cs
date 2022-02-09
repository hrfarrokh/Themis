using Ardalis.GuardClauses;

namespace Themis.Domain
{
    public abstract class ExhibitionOrder : Order
    {
        private City _city;
        private OrderItem _item;

        public ExhibitionOrder(ExhibitionOrder order)
            : this(order.Id,
                   order.TrackingCode,
                   order.Customer,
                   order.City,
                   order.Item)
        { }

        public ExhibitionOrder(OrderId id,
                               TrackingCode trackingCode,
                               Customer customer,
                               City city,
                               OrderItem item)
            : base(id, trackingCode)
        {
            Customer = Guard.Against.Null(customer);
            _city = Guard.Against.Null(city);
            _item = Guard.Against.Null(item);
        }

        public override OrderType Type => OrderType.Exhibition;
        public Customer Customer { get; }
        public City City => _city;
        public OrderItem Item => _item;
    }
}

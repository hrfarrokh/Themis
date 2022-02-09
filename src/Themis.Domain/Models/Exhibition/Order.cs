using Ardalis.GuardClauses;
using Themis.Core.Models;

namespace Themis.Domain
{

    public abstract class Order : AggregateBase<Order, OrderId>
    {
        protected Order(Order order) : this(order.Id, order.TrackingCode)
        {
        }

        protected Order(OrderId id,
                        TrackingCode trackingCode) : base(id)
        {
            TrackingCode = Guard.Against.Null(trackingCode);
        }

        public TrackingCode TrackingCode { get; }
        public abstract OrderType Type { get; }
        public abstract OrderState State { get; }
    }
}

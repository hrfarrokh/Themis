namespace Themis.Domain
{
    public class NewExhibitionOrder : ExhibitionOrder
    {
        public NewExhibitionOrder(OrderId id,
                                  TrackingCode trackingCode,
                                  Customer customer,
                                  City city,
                                  OrderItem item)
            : base(id,
                   trackingCode,
                   customer,
                   city,
                   item)
        {
        }

        public override ExhibitionOrderState State => ExhibitionOrderState.New;
    }
}

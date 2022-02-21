#nullable disable


namespace Themis.Application
{
    public class PlaceExhibitionOrderRequest : ICommand<PlaceExhibitionOrderResponse>
    {
        public const string Route = "/orders/exhibition";

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }

        public string CampaignCode { get; set; }
        public string Source { get; set; }
        public string PrevUrl { get; set; }
        public string OrderPageUrl { get; set; }
        public string PrevDomainUrl { get; set; }
        public string Referrer { get; set; }
        public string LandingPageUrl { get; set; }

        public class OrderItem
        {
            public long OrderId { get; set; }
            public int PackageId { get; set; }
            public Appointment Appointment { get; set; }
        }

        public class Appointment
        {
            public DateTime FromDateTime { get; set; }
            public DateTime ToDateTime { get; set; }
        }
    }
}

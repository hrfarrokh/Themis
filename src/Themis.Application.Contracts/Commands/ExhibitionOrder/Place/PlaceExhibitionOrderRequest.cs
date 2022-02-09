#nullable disable

namespace Themis.Application.Contracts
{
    public class PlaceExhibitionOrderAppointment
    {
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }
    }

    public class PlaceExhibitionOrderItem
    {
        public long OrderId { get; set; }
        public int PackageId { get; set; }
        public PlaceExhibitionOrderAppointment Appointment { get; set; }
    }

    public class PlaceExhibitionOrderRequest
    {
        public const string Route = "/orders/exhibition";

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public IEnumerable<PlaceExhibitionOrderItem> Items { get; set; }

        public string CampaignCode { get; set; }
        public string Source { get; set; }
        public string PrevUrl { get; set; }
        public string OrderPageUrl { get; set; }
        public string PrevDomainUrl { get; set; }
        public string Referrer { get; set; }
        public string LandingPageUrl { get; set; }
    }
}

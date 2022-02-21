namespace Themis.Application
{
    public class PlaceExhibitionOrderResponse
    {
        public PlaceExhibitionOrderResponse(string trackingCode) => TrackingCode = trackingCode;

        public string TrackingCode { get; set; }

    }
}

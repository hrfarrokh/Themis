# nullable disable

using Themis.Core.LhsBracket.Abstractions;

namespace Themis.Application
{
    public class ExhibitionOrderListQuery : ListQuery, IQuery<ListResponse<OrderListDto>>
    {
        public const string Route = "/orders/exhibition/";

        public FilterOperations<string> TrackingCode { get; set; }
        public FilterOperations<string> PhoneNumber { get; set; }
    }
}

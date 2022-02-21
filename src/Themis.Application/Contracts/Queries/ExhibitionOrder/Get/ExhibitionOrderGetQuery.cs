namespace Themis.Application
{

    public class ExhibitionOrderGetQuery : IQuery<OrderDto>
    {
        public const string Route = "/orders/exhibition/{id:guid}";

        public Guid Id { get; set; }
    }
}

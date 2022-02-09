namespace Themis.Application.Contracts
{
    public class ExhibitionOrderGetQuery
    {
        public const string Route = "/orders/exhibition/{id:guid}";

        public Guid Id { get; set; }
    }
}

#nullable disable

namespace Themis.Application.Contracts.Persistance
{
    public class PackageEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}

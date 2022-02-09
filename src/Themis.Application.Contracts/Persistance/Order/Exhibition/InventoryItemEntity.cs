#nullable disable

namespace Themis.Application.Contracts.Persistance
{
    public class InventoryItemEntity
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public CarEntity Car { get; set; }
        public CityEntity City { get; set; }
        public int Mileage { get; set; }
        public decimal Price { get; set; }
    }
}

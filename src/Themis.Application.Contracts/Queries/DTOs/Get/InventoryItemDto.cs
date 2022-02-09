# nullable disable

namespace Themis.Application.Contracts
{
    public class InventoryItemDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public CarDto Car { get; set; }
        public CityDto City { get; set; }
        public int Mileage { get; set; }
        public decimal Price { get; set; }
    }
}

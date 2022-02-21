using System.Text.Json.Serialization;
using Ardalis.GuardClauses;

namespace Themis.Application
{
    public interface IInventoryService
    {
        Task<InventoryItemServiceDto> GetAsync(long inventoryItemId);
    }

    public class InventoryItemServiceDto
    {
        [JsonConstructor]
        public InventoryItemServiceDto(int carId,
                                string carType,
                                string carGeneration,
                                string carBrand,
                                string carModel,
                                string carColor,
                                int carYear,
                                string fullName,
                                int cityId,
                                string cityTitle,
                                string cityDistrict,
                                int kilometer,
                                long price)
        {
            CarId = Guard.Against.NegativeOrZero(carId, nameof(carId));
            CarType = Guard.Against.NullOrWhiteSpace(carType, nameof(carType));
            CarGeneration = Guard.Against.NullOrWhiteSpace(carGeneration, nameof(carGeneration));
            CarBrand = Guard.Against.NullOrWhiteSpace(carBrand, nameof(carBrand));
            CarModel = Guard.Against.NullOrWhiteSpace(carModel, nameof(carModel));
            CarColor = Guard.Against.NullOrWhiteSpace(carColor, nameof(carColor));
            CarYear = Guard.Against.NegativeOrZero(carYear, nameof(carYear));
            FullName = Guard.Against.NullOrWhiteSpace(fullName, nameof(fullName));
            CityId = Guard.Against.NegativeOrZero(cityId, nameof(cityId));
            CityTitle = Guard.Against.NullOrWhiteSpace(cityTitle, nameof(cityTitle));
            CityDistrict = Guard.Against.NullOrWhiteSpace(cityDistrict, nameof(cityDistrict));
            Kilometer = Guard.Against.NegativeOrZero(kilometer, nameof(kilometer));
            Price = Guard.Against.NegativeOrZero(price, nameof(price));
        }

        public int CarId { get; set; }
        public string CarType { get; set; }
        public string CarGeneration { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
        public int CarYear { get; set; }
        public string FullName { get; set; }
        public int CityId { get; set; }
        public string CityTitle { get; set; }
        public string CityDistrict { get; set; }
        public int Kilometer { get; set; }
        public long Price { get; set; }
    }
}

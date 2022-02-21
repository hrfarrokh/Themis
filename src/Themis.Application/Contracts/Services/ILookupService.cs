using System.Text.Json.Serialization;

namespace Themis.Application
{
    public interface ILookupService
    {
        Task<CityLookupDto> GetCityAsync(int packageId);
    }

    public class CityLookupDto
    {
        [JsonConstructor]
        public CityLookupDto(int id, string name, string district)
        {
            Id = id;
            Name = name;
            District = district;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string District { get; }
    }
}

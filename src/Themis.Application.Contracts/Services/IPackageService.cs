using System.Text.Json.Serialization;

namespace Themis.Application.Contracts
{

    public interface IPackageService
    {
        Task<PackageServiceDto> GetAsync(int packageId, long price);
    }

    public class PackageServiceDto
    {
        [JsonConstructor]
        public PackageServiceDto(int id, string name, long price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
    }
}

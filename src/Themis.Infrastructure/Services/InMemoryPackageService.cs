using Themis.Application.Contracts;

namespace Themis.Infrastructure.Services
{
    public class InMemoryPackageService : IPackageService
    {
        public Task<PackageServiceDto> GetAsync(int packageId, long price)
        {
            var dto = new PackageServiceDto(packageId,
                                     "This is a package.",
                                     2_000_000);

            return Task.FromResult(dto);
        }
    }
}

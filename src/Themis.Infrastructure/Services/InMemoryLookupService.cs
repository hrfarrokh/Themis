using Themis.Application.Contracts;

namespace Themis.Infrastructure.Services
{
    public class InMemoryLookupService : ILookupService
    {
        public Task<CityLookupDto> GetCityAsync(int cityId)
        {
            var dto = new CityLookupDto(cityId,
                                  "This is a City Title.",
                                  "This is a City District.");

            return Task.FromResult(dto);
        }
    }
}

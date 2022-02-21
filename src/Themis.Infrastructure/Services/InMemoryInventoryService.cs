using Themis.Application;

namespace Themis.Infrastructure.Services
{
    public class InMemoryInventoryService : IInventoryService
    {
        public Task<InventoryItemServiceDto> GetAsync(long inventoryItemId)
        {
            var dto = new InventoryItemServiceDto(1008334,
                                           "This is a car type.",
                                           "This is a car generation.",
                                           "This is a car brand.",
                                           "This is a car model.",
                                           "This is a car color.",
                                           1400,
                                           "This is a full name.",
                                           8354343,
                                           "This is a city title.",
                                           "This is a city district.",
                                           21_000,
                                           210_000_000);

            return Task.FromResult(dto);
        }
    }
}


using Themis.Core.Models;

namespace Themis.Domain
{
    public interface IOrderRepository
    {
        Task<Order> FindByIdAsync(Uuid id,
                                  CancellationToken ct = default);
        Task CreateAsync(Order aggregate,
                         CancellationToken ct = default);
    }

}

using Themis.Application.Persistance;
using Themis.Domain;

namespace Themis.Infrastructure.Persistance
{
    public interface IOrderEntityMapper
    {
        void ToEntity(OrderEntityMapperContext context);
        Order ToAggregate(OrderEntity entity);
    }
}

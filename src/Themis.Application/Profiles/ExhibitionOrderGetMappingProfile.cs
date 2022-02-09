using AutoMapper;
using Themis.Application.Contracts;
using Themis.Application.Contracts.Persistance;

namespace Themis.Application
{
    public class ExhibitionOrderGetMappingProfile : Profile
    {
        public ExhibitionOrderGetMappingProfile()
        {
            CreateProjection<OrderEntity, OrderDto>();
            CreateProjection<CustomerEntity, CustomerDto>();
            CreateProjection<CityEntity, CityDto>();
            CreateProjection<OrderItemEntity, OrderItemDto>();
            CreateProjection<InventoryItemEntity, InventoryItemDto>();
            CreateProjection<PackageEntity, PackageDto>();
            CreateProjection<AppointmentEntity, AppointmentDto>();
            CreateProjection<CarEntity, CarDto>();
            CreateProjection<AuditEntity, AuditDto>();
        }
    }
}

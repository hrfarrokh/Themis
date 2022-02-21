using AutoMapper;
using Themis.Application;
using Themis.Application.Persistance;

namespace Themis.Application
{
    public class ExhibitionOrderListMappingProfile : Profile
    {
        public ExhibitionOrderListMappingProfile()
        {
            CreateProjection<OrderEntity, OrderListDto>()
                .ForMember(dto => dto.Key,
                           conf => conf.MapFrom(ent => ent.Id))
                .ForMember(dto => dto.Customer,
                           conf => conf.MapFrom(ent => $"{ent.Customer.FullName} - {ent.Customer.PhoneNumber}"))
                .ForMember(dto => dto.City,
                           conf => conf.MapFrom(ent => $"{ent.City.Title} - {ent.City.District}"))
                .ForMember(dto => dto.InventoryItem,
                           conf => conf.MapFrom(ent => ent.Item.InventoryItem))
                .ForMember(dto => dto.Package,
                           conf => conf.MapFrom(ent => ent.Item.Package.Title))
                .ForMember(dto => dto.Appointment,
                           conf => conf.MapFrom(ent => ent.Item.Appointment));

            CreateProjection<InventoryItemEntity, InventoryItemListDto>()
                .ForMember(dto => dto.Car,
                           conf => conf.MapFrom(ent => $"{ent.Car.Brand} - {ent.Car.Model} - {ent.Car.Year}"))
                .ForMember(dto => dto.City,
                           conf => conf.MapFrom(ent => $"{ent.City.Title} - {ent.City.District}"));

            CreateProjection<AuditEntity, AuditDto>();
        }
    }
}

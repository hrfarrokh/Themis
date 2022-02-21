using Themis.Application;
using Themis.Application.Persistance;
using Themis.Core;
using Themis.Domain;

namespace Themis.Infrastructure.Persistance
{
    public class NewExhibitionOrderMapper : IOrderEntityMapper
    {
        public Order ToAggregate(OrderEntity entity) => throw new NotImplementedException();

        public void ToEntity(OrderEntityMapperContext context)
        {
            var aggregate = context.Aggregate as NewExhibitionOrder;

            if (aggregate is null)
                throw new ArgumentException($"Type {context.Aggregate.GetType().Name} is not suitable for the mapper type {typeof(NewExhibitionOrderMapper).Name}");

            var entity = new OrderEntity
            {
                Id = aggregate.Id.Value,
                TrackingCode = aggregate.TrackingCode.Value,
                Type = aggregate.Type.Value,
                State = aggregate.State.Value,
                StateCategory = aggregate.State.Category.ToString(),
                Customer = new CustomerEntity
                {
                    Id = aggregate.Customer.Id.Value,
                    FullName = aggregate.Customer.FullName.Value,
                    PhoneNumber = aggregate.Customer.PhoneNumber.Value
                },
                City = new CityEntity
                {
                    Id = aggregate.City.Id,
                    Title = aggregate.City.Title,
                    District = aggregate.City.District
                },
                Item = new OrderItemEntity
                {
                    InventoryItem = new InventoryItemEntity
                    {
                        Id = aggregate.Item.InventoryItem.InventoryItemId.Value,
                        FullName = aggregate.Item.InventoryItem.FullName.Value,
                        Car = new CarEntity
                        {
                            Id = aggregate.Item.InventoryItem.Car.Id,
                            Type = aggregate.Item.InventoryItem.Car.Type,
                            Generation = aggregate.Item.InventoryItem.Car.Generation,
                            Brand = aggregate.Item.InventoryItem.Car.Brand,
                            Model = aggregate.Item.InventoryItem.Car.Model,
                            Color = aggregate.Item.InventoryItem.Car.Color,
                            Year = aggregate.Item.InventoryItem.Car.Year
                        },
                        City = new CityEntity
                        {
                            Id = aggregate.Item.InventoryItem.City.Id,
                            Title = aggregate.Item.InventoryItem.City.Title,
                            District = aggregate.Item.InventoryItem.City.District
                        },
                        Mileage = aggregate.Item.InventoryItem.Mileage.Value,
                        Price = aggregate.Item.InventoryItem.Price.Amount
                    },
                    Package = new PackageEntity
                    {
                        Id = aggregate.Item.Package.Id,
                        Title = aggregate.Item.Package.Title,
                        Price = aggregate.Item.Package.Price.Amount
                    },
                    Appointment = new AppointmentEntity
                    {
                        From = aggregate.Item.Appointment.From,
                        To = aggregate.Item.Appointment.To
                    },
                    TotalAmount = aggregate.Item.TotalAmount.Amount
                }
            };

            if (aggregate.Version == Core.Models.Version.Zero)
                entity.Creation = new AuditEntity
                {
                    UserId = context.UserId,
                    Username = context.Username,
                    TimeStamp = Clock.Now
                };

            entity.Modification = new AuditEntity
            {
                UserId = context.UserId,
                Username = context.Username,
                TimeStamp = Clock.Now
            };

            context.DbContext.Add(entity);
            // context.DbContext.Entry(entity).Reference(e => e.Customer).IsModified = true;
            // context.DbContext.Entry(entity).Reference(e => e.City).IsModified = true;
            // context.DbContext.Entry(entity).Reference(e => e.Item).IsModified = true;

            // context.DbContext.PartialUpdate(
            //     entity,
            //     e => e.TrackingCode,
            //     e => e.Type,
            //     e => e.State,
            //     e => e.ModifiedAt,
            //     e => e.ModifiedBy);

        }
    }
}

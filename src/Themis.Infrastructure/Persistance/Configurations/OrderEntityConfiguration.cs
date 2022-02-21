using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Themis.Application.Persistance;

namespace Themis.Infrastructure.Persistance
{
    class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.StringProperty(e => e.TrackingCode, isRequired: true);

            builder.StringProperty(e => e.Type, maxLength: 512, isRequired: true);

            builder.StringProperty(e => e.State, maxLength: 512, isRequired: true);

            builder.StringProperty(e => e.StateCategory, maxLength: 128, isRequired: true);

            builder.Property(e => e.Version)
                   .IsRowVersion();

            builder.OwnsOne(e => e.Creation, o =>
            {
                o.Property(e => e.TimeStamp).Metadata
                 .SetAfterSaveBehavior(PropertySaveBehavior.Throw);

                o.Property(o => o.Username)
                 .IsUnicode(true)
                 .HasMaxLength(128)
                 .IsRequired();
            });

            builder.Navigation(e => e.Creation)
                   .IsRequired();

            builder.OwnsOne(e => e.Modification, o =>
            {
                o.Property(e => e.TimeStamp);

                o.Property(o => o.Username)
                 .IsUnicode(true)
                 .HasMaxLength(128)
                 .IsRequired();
            });

            builder.Navigation(e => e.Modification)
                   .IsRequired();

            builder.OwnsOne(e => e.Customer, o =>
            {
                o.Property(o => o.Id);

                o.Property(o => o.FullName)
                 .IsUnicode(true)
                 .HasMaxLength(512)
                 .IsRequired();

                o.Property(o => o.PhoneNumber)
                 .IsUnicode(false)
                 .HasMaxLength(20)
                 .IsRequired();
            });

            builder.OwnsOne(e => e.Item, oio =>
            {
                oio.Property(e => e.TotalAmount)
                   .HasPrecision(18, 2)
                   .IsRequired();

                oio.OwnsOne(e => e.InventoryItem, iio =>
                {
                    iio.Property(o => o.Id);

                    iio.Property(o => o.FullName)
                       .IsUnicode(true)
                       .HasMaxLength(512)
                       .IsRequired();

                    iio.Property(e => e.Price)
                       .HasPrecision(18, 2)
                       .IsRequired();

                    iio.OwnsOne(e => e.Car, o =>
                    {
                        o.Property(o => o.Id);

                        o.Property(o => o.Type)
                         .IsUnicode(true)
                         .HasMaxLength(128)
                         .IsRequired();

                        o.Property(o => o.Generation)
                         .IsUnicode(true)
                         .HasMaxLength(128)
                         .IsRequired();

                        o.Property(o => o.Brand)
                         .IsUnicode(true)
                         .HasMaxLength(128)
                         .IsRequired();

                        o.Property(o => o.Model)
                         .IsUnicode(true)
                         .HasMaxLength(128)
                         .IsRequired();

                        o.Property(o => o.Color)
                         .IsUnicode(true)
                         .HasMaxLength(128)
                         .IsRequired();

                    });

                    iio.OwnsOne(e => e.City, co =>
                    {
                        co.Property(o => o.Id);

                        co.Property(o => o.Title)
                          .IsUnicode()
                          .HasMaxLength(128)
                          .IsRequired();

                        co.Property(o => o.District)
                          .IsUnicode()
                          .HasMaxLength(128)
                          .IsRequired();
                    });
                });

                oio.OwnsOne(e => e.Package, o =>
                {
                    o.Property(o => o.Id);

                    o.Property(o => o.Title)
                     .IsUnicode()
                     .HasMaxLength(128)
                     .IsRequired();
                });

                oio.OwnsOne(e => e.Appointment);
            });

            builder.OwnsOne(e => e.City, o =>
            {
                o.Property(o => o.Id);

                o.Property(o => o.Title)
                 .IsUnicode()
                 .HasMaxLength(128)
                 .IsRequired();

                o.Property(o => o.District)
                 .IsUnicode()
                 .HasMaxLength(128)
                 .IsRequired();
            });

        }
    }
}

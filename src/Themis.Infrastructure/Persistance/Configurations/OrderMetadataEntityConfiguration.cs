using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Themis.Application.Contracts.Persistance;

namespace Themis.Infrastructure.Persistance
{
    class OrderMetadataEntityConfiguration : IEntityTypeConfiguration<OrderMetadataEntity>
    {
        public void Configure(EntityTypeBuilder<OrderMetadataEntity> builder)
        {
            builder.Property(o => o.Channel)
                   .HasConversion<string>()
                   .IsUnicode(true)
                   .HasMaxLength(128)
                   .IsRequired();

            builder.Property(o => o.Origin)
                   .HasConversion<string>()
                   .IsUnicode(true)
                   .HasMaxLength(128)
                   .IsRequired();

            builder.Property(o => o.Source)
                   .HasConversion<string>()
                   .IsUnicode(true)
                   .HasMaxLength(128)
                   .IsRequired();

            builder.Property(o => o.Campaign)
                   .IsUnicode(true)
                   .HasMaxLength(512)
                   .IsRequired();

            builder.Property(o => o.PrevUrl)
                   .IsUnicode(true)
                   .HasMaxLength(2048)
                   .IsRequired();

            builder.Property(o => o.OrderPageUrl)
                   .IsUnicode(true)
                   .HasMaxLength(2048)
                   .IsRequired();

            builder.Property(o => o.PrevDomainUrl)
                   .IsUnicode(true)
                   .HasMaxLength(2048)
                   .IsRequired();

            builder.Property(o => o.Referrer)
                   .IsUnicode(true)
                   .HasMaxLength(1024)
                   .IsRequired();

            builder.Property(o => o.LandingPageUrl)
                   .IsUnicode(true)
                   .HasMaxLength(2048)
                   .IsRequired();

            builder.DateTimeProperty(e => e.CreatedAt).Metadata
                   .SetAfterSaveBehavior(PropertySaveBehavior.Throw);
        }
    }
}

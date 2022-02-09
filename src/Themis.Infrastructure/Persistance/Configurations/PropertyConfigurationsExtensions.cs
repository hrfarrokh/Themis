using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Themis.Infrastructure.Persistance
{
    public static class PropertyConfigurationsExtensions
    {
        public static PropertyBuilder StringProperty<TEntity>(
            this EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, string>> propertyExpression,
            int maxLength = 128,
            bool isUnicode = false,
            bool isRequired = false)
            where TEntity : class
            => builder.Property(propertyExpression)
                      .IsUnicode(isUnicode)
                      .HasMaxLength(maxLength)
                      .IsRequired(isRequired);

        public static PropertyBuilder DateTimeProperty<TEntity>(
            this EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, DateTimeOffset>> propertyExpression)
            where TEntity : class
            => builder.Property(propertyExpression)
                      .IsRequired(true);

        public static PropertyBuilder DateTimeProperty<TEntity>(
            this EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, DateTimeOffset?>> propertyExpression)
            where TEntity : class
            => builder.Property(propertyExpression)
                      .IsRequired(false);

        public static PropertyBuilder CurrencyProperty<TEntity>(
            this EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, decimal>> propertyExpression)
            where TEntity : class
            => builder.Property(propertyExpression)
                      .HasPrecision(18, 2)
                      .IsRequired(true);

        public static PropertyBuilder CurrencyProperty<TEntity>(
            this EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, decimal?>> propertyExpression)
            where TEntity : class
            => builder.Property(propertyExpression)
                      .HasPrecision(18, 2)
                      .IsRequired(false);

        public static PropertyBuilder EnumProperty<TEntity, TEnum>(
            this EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, TEnum>> propertyExpression,
            int maxLength = 128)
            where TEntity : class
            where TEnum : Enum
            => builder.Property(propertyExpression)
                      .HasConversion<string>()
                      .IsUnicode(false)
                      .HasMaxLength(maxLength)
                      .IsRequired(true);

        public static PropertyBuilder EnumProperty<TEntity, TEnum>(
            this EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, TEnum?>> propertyExpression,
            int maxLength = 128)
            where TEntity : class
            where TEnum : struct, IComparable, IConvertible, IFormattable
            => builder.Property(propertyExpression)
                      .HasConversion<string>()
                      .IsUnicode(false)
                      .IsRequired(false)
                      .HasMaxLength(maxLength);

    }
}

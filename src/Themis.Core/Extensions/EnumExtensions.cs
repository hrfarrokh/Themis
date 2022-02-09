using System.Diagnostics.CodeAnalysis;

namespace Themis.Core.Extensions
{
    public static class EnumExtensions
    {
        [return: NotNull]
        public static T ToEnum<T>(this string? value,
                                  T defaultValue)
                where T : struct, Enum
        {
            if (string.IsNullOrWhiteSpace(value))
                return defaultValue;

            Enum.TryParse<T>(value, true, out defaultValue);

            return defaultValue;
        }

    }
}

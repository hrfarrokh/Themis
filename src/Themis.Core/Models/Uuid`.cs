using System.Reflection;

namespace Themis.Core.Models
{
    public abstract class Uuid<TId> : Uuid
        where TId : Id, new()
    {
        private static readonly Func<string, TId>? s_parser;

        static Uuid()
        {
            MethodInfo? parserInfo = typeof(TId).GetMethod(
                name: nameof(Uuid<TId>.Parse),
                genericParameterCount: 0,
                bindingAttr: BindingFlags.Public | BindingFlags.Static,
                binder: null,
                types: new Type[] { typeof(string) },
                modifiers: null);

            if (parserInfo is null)
                return;

            s_parser = (Func<string, TId>)Delegate.CreateDelegate(typeof(Func<string, TId>),
                parserInfo);
        }

        protected Uuid()
        {
        }

        protected Uuid(Guid value)
            : base(value)
        {
        }


        public static TId New()
        {
            return new TId();
        }

        /// <summary>
        /// TId must have implemented Parse(string) static method.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TId Parse(string value)
        {
            return s_parser?.Invoke(value) ?? throw new NotSupportedException(
                $"Type `{typeof(TId).FullName}` does not have a static method `{typeof(TId).FullName} Parse(string value)`.");
        }
    }
}

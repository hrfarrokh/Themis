using Microsoft.AspNetCore.Mvc.ModelBinding;
using Themis.Core.LhsBracket.Abstractions;

namespace Themis.Core.LhsBracket.ModelBinder
{
    public class FilterModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var modelType = context.Metadata.UnderlyingOrModelType;

            if (modelType.IsGenericType && modelType.GetGenericTypeDefinition() == typeof(FilterOperations<>))
                return new FilterModelBinder();

            // if (typeof(IFilterRequest).IsAssignableFrom(context.Metadata.UnderlyingOrModelType))
            // {
            //     return new FilterModelBinder();
            // }

            return null;
        }
    }
}

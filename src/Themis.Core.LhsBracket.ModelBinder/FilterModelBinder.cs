using System.Collections.Concurrent;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Themis.Core.LhsBracket.Abstractions;

namespace Themis.Core.LhsBracket.ModelBinder
{
    public class FilterModelBinder : IModelBinder
    {
        private static ConcurrentDictionary<string, string> _cache = new();

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var modelType = bindingContext.ModelType;
            var filterRequestType = typeof(IFilterRequest);

            if (filterRequestType.IsAssignableTo(modelType))
                throw new ArgumentException($"The modeltype {modelType} does not inherit from {filterRequestType}");

            var inputType = bindingContext.ModelType.GetTypeInfo().GenericTypeArguments[0];
            var requestModel = Activator.CreateInstance(bindingContext.ModelType);

            foreach (var operation in Enum.GetValues<FilterOperationEnum>())
            {
                var valueProviderResult =
                    bindingContext.ValueProvider.GetValue($"{bindingContext.FieldName}[{operation.ToString()}]".ToLower());

                if (!valueProviderResult.Any())
                    continue;
                var filterOperation = requestModel as IFilterOperation;
                filterOperation.SetValue(operation,  valueProviderResult.FirstValue.ToString());
                // if (valueProviderResult.Length > 0)
                //     SetValueOnProperty(requestModel,
                //                        null,
                //                        operation,
                //                        (string)valueProviderResult.Values);
            }

            bindingContext.Result = ModelBindingResult.Success(requestModel);

            return Task.CompletedTask;
        }

        private static void SetValueOnProperty(object? requestModel,
                                               PropertyInfo prop,
                                               FilterOperationEnum operation,
                                               string value)
        {
            var propertyObject = prop.GetValue(requestModel, null);
            if (propertyObject == null) // property not instantiated
            {
                propertyObject = Activator.CreateInstance(prop.PropertyType);
                prop.SetValue(requestModel, propertyObject);
            }

            var method = prop.PropertyType.GetMethod(nameof(FilterOperations<object>.SetValue),
                                                     BindingFlags.Instance
                                                     | BindingFlags.Public);
            method!.Invoke(propertyObject, new object[] { operation, value });
        }
    }
}

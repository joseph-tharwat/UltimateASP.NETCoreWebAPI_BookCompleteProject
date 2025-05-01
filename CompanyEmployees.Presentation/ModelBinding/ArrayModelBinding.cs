using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.ModelBinding
{
    public class ArrayModelBinding : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (!bindingContext.ModelMetadata.IsEnumerableType)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

            var providedValue = bindingContext
                .ValueProvider
                .GetValue(bindingContext.ModelName)
                .ToString();
            if (string.IsNullOrEmpty(providedValue))
            {
                bindingContext .Result = ModelBindingResult.Success(null);
                return Task.CompletedTask;
            }

            var GenericType = bindingContext.ModelType.GetTypeInfo().GetGenericArguments()[0];

            var converter = TypeDescriptor.GetConverter(GenericType);

            var StringArray = providedValue.Split( "," );

            var objectArray = StringArray
                .Select(str => converter.ConvertFromString(str))
                .ToArray();

            var GuidArrayResult = Array.CreateInstance(GenericType, objectArray.Length);
            objectArray.CopyTo(GuidArrayResult, 0);

            bindingContext.Model = GuidArrayResult;
            bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);
            return Task.CompletedTask;
        }
    }
}

using BibliotecaWeb.Models;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BibliotecaWeb.Filter
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly IModelMetadataProvider modelMetadataProvider;

        public CustomExceptionFilter(IModelMetadataProvider modelMetadataProvider)
        {
            this.modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            var result = new ViewResult { ViewName = "Error" };
            result.ViewData = new ViewDataDictionary(modelMetadataProvider, context.ModelState);
            result.ViewData["Exception"] =  context.Exception;
            
            // mark exception as handled
            context.ExceptionHandled = true; 
            context.Result = result;
        }
    }
}

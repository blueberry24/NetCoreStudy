using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace NetCoreStudy.WebAPI.Extensions
{
    public class CustomActionJsonFormatAttribute : ActionFilterAttribute
    {
        private Type _ContractResolver { get; set; }
        public CustomActionJsonFormatAttribute(Type ContractResolver)
        {
            _ContractResolver = ContractResolver;
        }
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            var jsonResult = (JsonResult)actionExecutedContext.Result;

            IContractResolver contract = Activator.CreateInstance(_ContractResolver) as IContractResolver;
            jsonResult.SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = contract
            };

            actionExecutedContext.Result = jsonResult;
        }
    }
}

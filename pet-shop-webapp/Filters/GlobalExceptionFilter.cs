using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace pet_shop.api.Filters
{
    public class GlobalExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(context.Exception.Message);
            
            context.ExceptionHandled = true;
        }
    }
}
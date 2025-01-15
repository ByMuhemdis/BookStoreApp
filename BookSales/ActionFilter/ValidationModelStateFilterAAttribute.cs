using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookSales.ActionFilter
{
    public class ValidationModelStateFilterAAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //kontext üzerinden hangi controllerda oldugumuzu bulalım

            var controller = context.RouteData.Values["controller"];
            //Eylemleri bulmak için 

            var action =context.RouteData.Values["action"];

            //Parametre bilgilerini alalım

            var param= context.ActionArguments.SingleOrDefault(P=>P.Value.ToString().Contains("Dto")).Value;

            if (param is null )
            {
                context.Result = new BadRequestObjectResult($"object is null " +
                    $"Controller : {controller}" +
                    $"Action     : {action}");

                return;//400
            }

            if (!context.ModelState.IsValid ) 
                context.Result =new UnprocessableEntityObjectResult(context.ModelState);
         }
    }
}

using Entities.ErrorModels;
using Entities.LogActionDetails;
using Microsoft.AspNetCore.Mvc.Filters;
using Stroe.Services.IService;

namespace BookSales.ActionFilter
{
    public class LogFilterAttrubute : ActionFilterAttribute
    {
        private readonly ILoggerService _loggerService;

        public LogFilterAttrubute(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _loggerService.logInfo(Log("OnActionExecuting", context.RouteData));
        }

        private string Log(string modelName, RouteData routeData)
        {
            var logdetails = new LogActionDetail()
            {
                ModelName =modelName,
                Controller = routeData.Values["controller"],
                Action = routeData.Values["action"]
                
            };
            ///localhost500//about/getallAbout/id
            ///burdada anahtarda her zamanid olmaya bilir o zman id anahtar sayısını kontrol ederek var ise id ekle demem gerek 
            ///
            if(routeData.Values.Count >=3) 
                logdetails.id = routeData.Values["id"];
             
            return logdetails.ToString();
        }
    }
}

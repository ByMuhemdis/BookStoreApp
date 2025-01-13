
using Entities.ErrorModels;
using Microsoft.AspNetCore.Diagnostics;
using Store.Application.ErrorExceptions;
using Stroe.Services.IService;
using System.Net;

namespace BookSales.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfugureExceptionhandler(this WebApplication app,ILoggerService logger) 
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                  
                    context.Response.ContentType = "application/json";
                    
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();//Bir hata varmı oa bakıyoruz
                    if (contextFeature is not null)//hata var ise null gelmeyecektir o zman bu hatayı ErrorDetails Kısmında yazdırıp ekrana vereefiz 
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFounException => StatusCodes.Status404NotFound,
                            BadRequestException => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError
                        };
                        logger.logError($"someting went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails() 
                        {
                            StatusCode=context.Response.StatusCode,
                            Message = contextFeature.Error.Message

                        }.ToString());
                    }
                });
            });
        }
    }
}

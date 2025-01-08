using Microsoft.Extensions.DependencyInjection;
using Stroe.Services.IService;
using Stroe.Services.IService.IAuthorServices;
using Stroe.Services.IService.IBookServices;
using Stroe.Services.ServicesManager;
using Stroe.Services.ServicesManager.AuthorManagers;
using Stroe.Services.ServicesManager.BookManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroe.Services.Extensions
{
    public static class ServicesRegistrations
    {
        public static void ConfugureServices(this IServiceCollection services)
        {
            //istersek butun oluşturulan serviceleri ayrı ayrı kaydedip istenilen yerde istenilen service yu çagırarak işlemlere devam edebiliriz istersek de
            //manager ile tek kayıtta butun servislerin tamamına  ualaşa biliriz.
            services.AddScoped<IServiceManager, ServiceManager>();
            //Author Service Ioc Kaydı.
            services.AddScoped<IAuthorService, AuthorManager>();
            //Book Service IOC kaydı.
            services.AddScoped<IBookService, BookManager>();

            /// istege göre digerleride kaydedilebilir biz burada kısa yoldan service manager uzerinden servistelirn tamamına ulaşacagız.
            /// 

        }
    }
}

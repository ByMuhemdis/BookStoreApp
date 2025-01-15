using BookSales.ActionFilter;
using BookSales.Extensions;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Store.Application.Extensions;
using Store.Persistence.Extensions;
using Stroe.Services.Extensions;
using Stroe.Services.IService;
namespace BookSales
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Loglama için bir IOCkaydý yaparak iþlemlere devam edecegiz
            LogManager.Setup().LoadConfigurationFromFile($"{Directory.GetCurrentDirectory()}/nlog.config"); //***NLog'un yapýlandýrma ayarlarýný nlog.config dosyasýndan yükler.
            var loggers = LogManager.GetCurrentClassLogger();
            loggers.Info("Application started.");  // Uygulamanýn baþlangýç logu.
            // Add services to the container.

            //***iÇERÝK PAZARLÝÝGÝ ÝÇÝN aþagýya config ekleyip iþlemlere devam edelim 
            builder.Services.AddControllers(
                //içerik pazarlýgýyla isteklere göre dönüþ yapabiliyoruz örn text/xml --aplicationjson/xml -- text/csv--- aplicationjson/json þeklinde
                //istekler gelebilir biz burada bu isteklere izin verdigimizi söylüyoruz. yazi pazarlýga acýgýz ama istedgin formatta bir cýktý veremedgi iöin hata verecektir 
                //burada default olarak application/json olarak çýktý alýabiliriz ama bunlarý yazdýgýmýz için önceen hangi sekilde çagýrýrsan çagýralým
                // aplication/json formatýnda dönderiyordu ama artýk bu format haricinde diger formatlarda hata verdirdik  orada hata veriyor.   
                config =>
                {
                    config.RespectBrowserAcceptHeader = true;
                    config.ReturnHttpNotAcceptable=true;
                }).AddXmlDataContractSerializerFormatters();//***ÝÇERÝK PAZARLIGI bu satýrla beraber xml formatýnda da çýkýþ vermemize olanak saglar.
                                                            //bununla beraber bir dto serilaz edilmesi gerekir. ki hata ile karþýlaþýlmasýn.


            //model state invalid iþlemi = Dogrulamaiþlemi veri tabanýna gidecek kýsmý kontolu saglanýyor.
            builder.Services.Configure<ApiBehaviorOptions>(confing =>
            {
                confing.SuppressModelStateInvalidFilter = true;
            });
            //**logFilterAttrubute için bir IOc kaydý yapýldý.
            builder.Services.AddSingleton<LogFilterAttrubute>();
            builder.Services.AddScoped<ValidationModelStateFilterAAttribute>();


            builder.Services.AddEndpointsApiExplorer(); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerGen();

            //Database Kaydý 
            builder.Services.ConfugureSqlDbConetxt(builder.Configuration);

            //Repositoryler veya Rpository kaydýný yapýyoruz bu yuzden oluþturudugumuz sýnýfýn adýný yazýyoruz
            builder.Services.ConfugureRepositoryManager();
            //Serviceler için Manager veya tek tek kaydettigmz Extencation kýsmýndaki confugurayyonu buraya tanýmlayarak serviceleri her yerde kullanalým.
            builder.Services.ConfugureServices();

            //***Automapper kutuphanesini indirdikten sonra buraya IOC kaydýný yapalým
            builder.Services.AutoMapperDTOService();

            //Cors Yapýlandýrýlmasý

            builder.Services.ConfugureCors();//app den sonrada usersors yazalým.


            var app = builder.Build();

            //Global hata yönetimini burada yapýlandýrmamýz gerekle 

            var logger = app.Services.GetRequiredService<ILoggerService>();//burada loggingserviceyi çözüyoruz 
            app.ConfugureExceptionhandler(logger);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            if (app.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //cors Yapýlandýrýlmasý
            app.UseCors("CorsPolicy");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

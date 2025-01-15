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
            // Loglama i�in bir IOCkayd� yaparak i�lemlere devam edecegiz
            LogManager.Setup().LoadConfigurationFromFile($"{Directory.GetCurrentDirectory()}/nlog.config"); //***NLog'un yap�land�rma ayarlar�n� nlog.config dosyas�ndan y�kler.
            var loggers = LogManager.GetCurrentClassLogger();
            loggers.Info("Application started.");  // Uygulaman�n ba�lang�� logu.
            // Add services to the container.

            //***i�ER�K PAZARL��G� ���N a�ag�ya config ekleyip i�lemlere devam edelim 
            builder.Services.AddControllers(
                //i�erik pazarl�g�yla isteklere g�re d�n�� yapabiliyoruz �rn text/xml --aplicationjson/xml -- text/csv--- aplicationjson/json �eklinde
                //istekler gelebilir biz burada bu isteklere izin verdigimizi s�yl�yoruz. yazi pazarl�ga ac�g�z ama istedgin formatta bir c�kt� veremedgi i�in hata verecektir 
                //burada default olarak application/json olarak ��kt� al�abiliriz ama bunlar� yazd�g�m�z i�in �nceen hangi sekilde �ag�r�rsan �ag�ral�m
                // aplication/json format�nda d�nderiyordu ama art�k bu format haricinde diger formatlarda hata verdirdik  orada hata veriyor.   
                config =>
                {
                    config.RespectBrowserAcceptHeader = true;
                    config.ReturnHttpNotAcceptable=true;
                }).AddXmlDataContractSerializerFormatters();//***��ER�K PAZARLIGI bu sat�rla beraber xml format�nda da ��k�� vermemize olanak saglar.
                                                            //bununla beraber bir dto serilaz edilmesi gerekir. ki hata ile kar��la��lmas�n.


            //model state invalid i�lemi = Dogrulamai�lemi veri taban�na gidecek k�sm� kontolu saglan�yor.
            builder.Services.Configure<ApiBehaviorOptions>(confing =>
            {
                confing.SuppressModelStateInvalidFilter = true;
            });
            //**logFilterAttrubute i�in bir IOc kayd� yap�ld�.
            builder.Services.AddSingleton<LogFilterAttrubute>();
            builder.Services.AddScoped<ValidationModelStateFilterAAttribute>();


            builder.Services.AddEndpointsApiExplorer(); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerGen();

            //Database Kayd� 
            builder.Services.ConfugureSqlDbConetxt(builder.Configuration);

            //Repositoryler veya Rpository kayd�n� yap�yoruz bu yuzden olu�turudugumuz s�n�f�n ad�n� yaz�yoruz
            builder.Services.ConfugureRepositoryManager();
            //Serviceler i�in Manager veya tek tek kaydettigmz Extencation k�sm�ndaki confugurayyonu buraya tan�mlayarak serviceleri her yerde kullanal�m.
            builder.Services.ConfugureServices();

            //***Automapper kutuphanesini indirdikten sonra buraya IOC kayd�n� yapal�m
            builder.Services.AutoMapperDTOService();

            //Cors Yap�land�r�lmas�

            builder.Services.ConfugureCors();//app den sonrada usersors yazal�m.


            var app = builder.Build();

            //Global hata y�netimini burada yap�land�rmam�z gerekle 

            var logger = app.Services.GetRequiredService<ILoggerService>();//burada loggingserviceyi ��z�yoruz 
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
            //cors Yap�land�r�lmas�
            app.UseCors("CorsPolicy");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

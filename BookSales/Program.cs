using BookSales.Extensions;
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

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Database Kayd� 
            builder.Services.ConfugureSqlDbConetxt(builder.Configuration);

            //Repositoryler veya Rpository kayd�n� yap�yoruz bu yuzden olu�turudugumuz s�n�f�n ad�n� yaz�yoruz
            builder.Services.ConfugureRepositoryManager();
            //Serviceler i�in Manager veya tek tek kaydettigmz Extencation k�sm�ndaki confugurayyonu buraya tan�mlayarak serviceleri her yerde kullanal�m.
            builder.Services.ConfugureServices();

            //***Automapper kutuphanesini indirdikten sonra buraya IOC kayd�n� yapal�m
            builder.Services.AutoMapperDTOService();




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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

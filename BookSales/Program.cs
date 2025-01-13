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
            // Loglama için bir IOCkaydý yaparak iþlemlere devam edecegiz
            LogManager.Setup().LoadConfigurationFromFile($"{Directory.GetCurrentDirectory()}/nlog.config"); //***NLog'un yapýlandýrma ayarlarýný nlog.config dosyasýndan yükler.
            var loggers = LogManager.GetCurrentClassLogger();
            loggers.Info("Application started.");  // Uygulamanýn baþlangýç logu.
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Database Kaydý 
            builder.Services.ConfugureSqlDbConetxt(builder.Configuration);

            //Repositoryler veya Rpository kaydýný yapýyoruz bu yuzden oluþturudugumuz sýnýfýn adýný yazýyoruz
            builder.Services.ConfugureRepositoryManager();
            //Serviceler için Manager veya tek tek kaydettigmz Extencation kýsmýndaki confugurayyonu buraya tanýmlayarak serviceleri her yerde kullanalým.
            builder.Services.ConfugureServices();

            //***Automapper kutuphanesini indirdikten sonra buraya IOC kaydýný yapalým
            builder.Services.AutoMapperDTOService();




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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

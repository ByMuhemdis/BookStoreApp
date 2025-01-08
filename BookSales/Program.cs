using Store.Persistence.Extensions;
using Stroe.Services.Extensions;
namespace BookSales
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

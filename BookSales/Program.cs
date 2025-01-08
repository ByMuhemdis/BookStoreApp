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

            //Database Kayd� 
            builder.Services.ConfugureSqlDbConetxt(builder.Configuration);

            //Repositoryler veya Rpository kayd�n� yap�yoruz bu yuzden olu�turudugumuz s�n�f�n ad�n� yaz�yoruz
            builder.Services.ConfugureRepositoryManager();
            //Serviceler i�in Manager veya tek tek kaydettigmz Extencation k�sm�ndaki confugurayyonu buraya tan�mlayarak serviceleri her yerde kullanal�m.
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

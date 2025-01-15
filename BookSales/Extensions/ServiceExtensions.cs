namespace BookSales.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfugureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>

                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("X-Pagination")

                 );

            });
        }
    }
}

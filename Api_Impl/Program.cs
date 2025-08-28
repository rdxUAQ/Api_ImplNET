using ApiImpl.Interfaces;
using ApiImpl.Services;

namespace ApiImpl
{
    class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder();

            // Add services to the container.
            builder.Services.AddTransient<IProductsService, ProductsService>();

            builder.Services.AddControllers();
            
            builder.Services.AddScoped<LoggerService>();
            builder.Services.AddScoped<DtoValidationService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            // Remove HTTPS redirection so you can test with http

            // app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestaurantBookingAPI.Data;

namespace RestaurantBookingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();//DI configuration,one instance be given
            builder.Services.AddScoped<IRestaurantService, RestaurantService>();//DI configuration,one instance be given
            /*builder.Services.AddTransient<IRestaurantRepository, RestaurantRepository>();//every single time new instace calss given
            builder.Services.AddSingleton<IRestaurantRepository, RestaurantRepository>();//For whole app only one instance,danger for common use as its not thread safe*/

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            /*builder.Services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));*/
            var configuration = builder.Configuration;
            builder.Services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") ?? "").
           EnableSensitiveDataLogging());//should not be used in production,only for development purpose
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

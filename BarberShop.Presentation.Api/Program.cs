
using BarberShop.Application.Profiles;
using BarberShop.Infra.Data.Context;
using BarberShop.Infra.Ioc;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Presentation.Api
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
            var connection = builder.Configuration.GetConnectionString("BarberShopDb");
            builder.Services.AddDbContext<BarberShopContext>(options => options.
                UseSqlServer(connection)
                .UseLazyLoadingProxies()
            );
            builder.Services.AddAutoMapper(typeof(MappiingProfile).Assembly);
            DependencyContainer.RegisterServices(builder.Services);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

using MarketAPI.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MarketAPI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Persistence service'i ekliyoruz.
            builder.Services.AddPersistenceService();
           builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()
           ));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();
            // HTTPS yönlendirmesini eklemek için
            app.UseHttpsRedirection();

            // Authorization'ý eklemek için
            app.UseAuthorization();

            // Controllers'larý haritalamak
            app.MapControllers();

            // Uygulamayý çalýþtýrmak
            app.Run();
        }
    }
}

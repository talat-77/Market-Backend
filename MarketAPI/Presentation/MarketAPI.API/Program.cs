using MarketAPI.Infrastructure;
using MarketAPI.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            builder.Services.AddAuthentication("Admin")
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateAudience= true,
                        ValidateIssuer= true,   
                        ValidateLifetime= true,
                        ValidateIssuerSigningKey= true,

                        ValidAudience = builder.Configuration["Token:Audience"],
                        ValidIssuer= builder.Configuration["Token:Issuer"],
                        IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
                        
                    };
                });

            // Persistence service'i ekliyoruz.
            
            builder.Services.AddPersistenceService();
           builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()
           ));
            builder.Services.AddInfraStructureService(builder.Configuration);

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
            app.UseAuthentication();
            // Authorization'ý eklemek için
            app.UseAuthorization();

            // Controllers'larý haritalamak
            app.MapControllers();

            // Uygulamayý çalýþtýrmak
            app.Run();
        }
    }
}

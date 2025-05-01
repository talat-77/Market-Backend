using MarketAPI.Application.Repositories.CustomerRepository;
using MarketAPI.Application.Repositories.OrderRepository;
using MarketAPI.Application.Repositories.ProductRepository;
using MarketAPI.Domain.Entities;
using MarketAPI.Persistence.Contexts;
using MarketAPI.Persistence.Repositories.CustomerReadRepository;
using MarketAPI.Persistence.Repositories.CustomerRepository;
using MarketAPI.Persistence.Repositories.OrderRepository;
using MarketAPI.Persistence.Repositories.ProductRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<MarketAPIDbContext>(options => options.UseNpgsql(Configurations.ConnecitonString));
            services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository,CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository,OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository,OrderWriteRepository>();
            services.AddScoped<IProductReadRepository,ProductReadRepository>();
            services.AddScoped<IProductWriteRepository,ProductWriteRepository>();
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6; // Örnek bir ekleme
            })
                .AddEntityFrameworkStores<MarketAPIDbContext>()
                .AddDefaultTokenProviders();

            // DataProtection servisi ekleme (eğer varsa)
            services.AddDataProtection();



        }
    }
}
    
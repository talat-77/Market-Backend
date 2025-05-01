using Azure.Storage.Blobs;
using MarketAPI.Application.Abstractions.Storage;
using MarketAPI.Application.Abstractions.Token;
using MarketAPI.Infrastructure.Services.FileStorage;
using MarketAPI.Infrastructure.Services.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Infrastructure
{
    public static class InfraServiceRegistration
    {
        public static void AddInfraStructureService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IFileStorageService, AzureBlobStorageService>();
            services.AddSingleton(x =>
               new BlobContainerClient(
                   x.GetRequiredService<IConfiguration>().GetSection("AzureBlobSettings")["ConnectionString"],
                   x.GetRequiredService<IConfiguration>().GetSection("AzureBlobSettings")["ContainerName"]
               ));//burada BlobContainerClient için connectionstring ve containername verilerini appsetting.json okuma yapıyoruz. Getrequiredservice böyle bir servisin olduğunu garanti eder aksi durumda exeption fırlatır

        }
    }
}

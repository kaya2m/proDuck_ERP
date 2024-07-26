using proDuck.Application.Abstraction.Storage;
using proDuck.Application.Abstraction.Token;
using proDuck.Application.DTOs;
using proDuck.Infrastructure.Services;
using proDuck.Infrastructure.Services.Storage;
using proDuck.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Infrastructure
{
    public static class ServiceRegistration 
    {
        public static void AddInfrastrustureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler,Infrastructure.Services.Token.TokenHandler>();

            services.AddScoped<IStorageService, StorageService>();
        }
        public static void AddStorage<T>(this IServiceCollection services) where T :Storage, IStorage
        {
            services.AddScoped<IStorage, T>();
        }
    }
}

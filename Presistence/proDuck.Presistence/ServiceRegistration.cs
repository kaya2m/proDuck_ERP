using proDuck.Application.Repositories.CustomerInterface;
using proDuck.Application.Repositories.FileInterface;
using proDuck.Application.Repositories.InvoiceFileInterface;
using proDuck.Application.Repositories.OrderInterface;
using proDuck.Application.Repositories.ProductImageFileInterface;
using proDuck.Application.Repositories.ProductInterface;
using proDuck.Domain.Entities.Identity;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories.CostumerRepositories;
using proDuck.Persistence.Repositories.FileRepositories;
using proDuck.Persistence.Repositories.InvoiceRepositories;
using proDuck.Persistence.Repositories.OrderRepositories;
using proDuck.Persistence.Repositories.ProductImageRepositories;
using proDuck.Persistence.Repositories.ProductRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using proDuck.Application.Abstraction.Services;
using proDuck.Persistence.Services;
using proDuck.Application.Abstraction.Services.Authentication;

namespace proDuck.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {

            ConfigurationManager configuration = new();
            configuration.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/proDuck.WebApi"));
            configuration.AddJsonFile("appsettings.json");

            services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<proDuckDbContext>();

            services.AddDbContext<proDuckDbContext>(options =>
                 options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));

            services.AddScoped<ICostumerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICostumerWriteRepository, CostumerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRespository>();
            services.AddScoped<IInvoceFileReadRepository, InvoiceFileReadRepository>();
            services.AddScoped<IInvoceFileWriteRepository, InvoiceWriteRepository>();
            services.AddScoped<IProductImageFileReadRepository,ProductImagesReadRepsoitory>();
            services.AddScoped<IProductImageFileWriteRepository, ProductImagesWriteRepsoitory>();

            services.AddScoped<IUser, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthentication, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();
        }
    }
}

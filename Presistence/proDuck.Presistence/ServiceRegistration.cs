using proDuck.Application.Repositories.CustomerInterface;
using proDuck.Application.Repositories.FileInterface;
using proDuck.Application.Repositories.InvoiceFileInterface;
using proDuck.Application.Repositories.ProductImageFileInterface;
using proDuck.Domain.Entities.Identity;
using proDuck.Persistence.Context;
using proDuck.Persistence.Repositories.FileRepositories;
using proDuck.Persistence.Repositories.InvoiceRepositories;
using proDuck.Persistence.Repositories.ProductImageRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using proDuck.Application.Abstraction.Services;
using proDuck.Persistence.Services;
using proDuck.Application.Abstraction.Services.Authentication;
using proDuck.Presistence.Repositories.CustomerRepositories;

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

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            //services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            //services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            //services.AddScoped<IProductReadRepository, ProductReadRepository>();
            //services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            //services.AddScoped<IFileReadRepository, FileReadRepository>();
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

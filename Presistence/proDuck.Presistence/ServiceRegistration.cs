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
using proDuck.Application.Abstraction.Services;
using proDuck.Persistence.Services;
using proDuck.Application.Abstraction.Services.Authentication;
using proDuck.Presistence.Repositories.CustomerRepositories;
using proDuck.Application.Repositories.ShippingAddressInterface;
using proDuck.Presistence.Repositories.ShippingAddressRepositories;
using proDuck.Application.Repositories.ProposalInterfaces.MeetingInterface;
using proDuck.Presistence.Repositories.ProposalsRepositories.MeetingRepositories;
using proDuck.Presistence.Repositories.ProposalsRepositories.ProposalDetailRepositories;
using proDuck.Presistence.Repositories.ProposalsRepositories.ProposalRepositories;
using proDuck.Application.Repositories.ProposalInterfaces.ProposalInterface;
using proDuck.Application.Repositories.ProposalInterfaces.ProposalDetailInterface;
using proDuck.Application.Repositories.OrderInterface.Order;
using proDuck.Presistence.Repositories.OrdersRepositories.OrderRepositories;
using proDuck.Presistence.Repositories.OrdersRepositories.OrderDetailRepositories;
using proDuck.Application.Repositories.OrderInterface.OrderDetail;
using proDuck.Presistence.Repositories.ProductCardRepositories.ProductCardRepositories;
using proDuck.Application.Repositories.ProductCardInterfaces.ProductCardInterface;
using proDuck.Presistence.Repositories.ProductCardRepositories.PalletRespositories;
using proDuck.Presistence.Repositories.ProductCardRepositories.CategoryRepositories;
using proDuck.Application.Repositories.ProductCardInterfaces.CategoryInterface;
using proDuck.Presistence.Repositories.ProductCardRepositories.ModelTypeRepositories;
using proDuck.Application.Repositories.ProductCardInterfaces.PalletInterface;
using proDuck.Application.Repositories.ProductCardInterfaces.ModelTypeInterface;
using proDuck.Application.Repositories.AddressInterface;
using proDuck.Presistence.Repositories.AddressRepositories;

namespace proDuck.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {

            ConfigurationManager configuration = new();
            configuration.SetBasePath(AppContext.BaseDirectory);
            configuration.AddJsonFile("appsettings.json");

            services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<proDuckDbContext>();

            services.AddDbContext<proDuckDbContext>(options =>
                 options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IShippingAddressReadRepository, ShippingAddressReadRepository>();
            services.AddScoped<IShippingAddressWriteRepository, ShippingAddressWriteRepository>();
            services.AddScoped<IMeetingReadRepository,  MeetingReadRepository>();
            services.AddScoped<IMeetingWriteRepository, MeetingWriteRepository>();
            services.AddScoped<IProposalReadRepository,  ProposalReadRepository>();
            services.AddScoped<IProposalWriteRepository, ProposalWriteRepository>();
            services.AddScoped<IProposalDetailReadRepository,  ProposalDetailReadRepository>();
            services.AddScoped<IProposalDetailWriteRepository, ProposalDetailWriteRepository>();
            services.AddScoped<IOrderDetailReadRepository,  OrderDetailReadRepository>();
            services.AddScoped<IOrderDetailWriteRepository, OrderDetailWriteRepository>();
            services.AddScoped<IProductCardReadRepository,  ProductCardReadRepository>();
            services.AddScoped<IProductCardWriteRepository, ProductCardWriteRepository>(); 
            services.AddScoped<IPalletReadRepository,  PalletReadRepository>();
            services.AddScoped<IPalletWriteRepository, PalletWriteRepository>();
            services.AddScoped<ICategoryReadRepository,  CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<IModelTypeReadRepository,  ModelTypeReadRepository>();
            services.AddScoped<IModelTypeWriteRepository, ModelTypeWriteRepository>();

            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRespository>();
            services.AddScoped<IInvoceFileReadRepository, InvoiceFileReadRepository>();
            services.AddScoped<IInvoceFileWriteRepository, InvoiceWriteRepository>();
            services.AddScoped<IProductImageFileReadRepository, ProductImagesReadRepsoitory>();
            services.AddScoped<IProductImageFileWriteRepository, ProductImagesWriteRepsoitory>();

            services.AddScoped<ICountryReadRepository, CountryReadRepository>();
            services.AddScoped<ICityReadRepository, CityReadRepository>();
            services.AddScoped<IDistrictReadRepository, DistrictReadRepository>();
            services.AddScoped<INeighborhoodReadRepository, NeighborhoodReadRepository>();


            services.AddScoped<IUser, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthentication, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();
        }
    }
}

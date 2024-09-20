using proDuck.Application;
using proDuck.Infrastructure;
using proDuck.Infrastructure.Filters;
using proDuck.Infrastructure.Services.Storage.Azure;
using proDuck.Persistence;
using proDuck.WebApi.Configuration;

namespace proDuck.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddPersistenceService();
        builder.Services.AddInfrastrustureServices();
        builder.Services.AddApplicationServices();
        builder.Services.AddStorage<AzureStorage>();
        builder.Services.AddHttpClient();
        builder.Services.ConfigureSwaggerSetting();
        builder.Services.ConfigureCors();
        builder.Services.ConfigureJWT(builder.Configuration);
        builder.Services.AddControllers(options => options.Filters.Add<ValidationFilters>())
            .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

        builder.Services.AddEndpointsApiExplorer();
       

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseStaticFiles();

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors();

        app.MapControllers();

        app.Run();
    }
}
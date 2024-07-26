using proDuck.Application;
using proDuck.Application.Validators.Products;
using proDuck.Infrastructure;
using proDuck.Infrastructure.Filters;
using proDuck.Infrastructure.Services.Storage.Azure;
using proDuck.Infrastructure.Services.Storage.Local;
using proDuck.Persistence;
using proDuck.Persistence.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation.AspNetCore;

namespace proDuck.Presentation
{
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

            builder.Services.AddControllers(options => options.Filters.Add<ValidationFilters>())
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CreateProductValidatior>())
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("Admin", options => options.TokenValidationParameters = new()
                {
                    ValidateAudience = true, // token deðerini kimlerin kullanacaðýýn belirtir
                    ValidateIssuer = true, // tokeni kim,n ouþturacaðýný brlirtir
                    ValidateLifetime = true, // tokenin geçerlilik süresini belirtir
                    ValidateIssuerSigningKey = true,// tokenin hangi anahtar ile þifrelendiðini belirtir

                    ValidAudience = builder.Configuration["Token:Audience"],
                    ValidIssuer = builder.Configuration["Token:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
                }); ;
            builder.Services.AddCors(opt => opt.AddDefaultPolicy(poilcy => poilcy
            .WithOrigins("http://localhost:4200", "https://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()));
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
}
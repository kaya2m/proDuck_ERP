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
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;

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
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "1.0.1",
                    Description = "<h1>proDuck ERP API</h1>\r\n            <p>proDuck ERP API, bir DuckSolution ürünüdür. proDuck, üretim ve fabrika yönetimi için kapsamlý çözümler sunar.<br> \r\n            Bu yazýlým çözümü, fabrikalar ve üretim merkezleri için verimliliði artýrmayý ve maliyetleri düþürmeyi amaçlamaktadýr. \r\n            <br> Kullanýcý dostu arayüzü ve güçlü analitik araçlarý ile iþletmelerin süreçlerini optimize etmelerine yardýmcý olur.</p>",
                    Extensions =
                            {
                                { "proDuck", new OpenApiObject
                                    {
                                        { "url", new OpenApiString("https://example.com/logo.png") },
                                        { "altText", new OpenApiString("proDuck Logo") }
                                    }
                                }
                            },
                    
                });
            });
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
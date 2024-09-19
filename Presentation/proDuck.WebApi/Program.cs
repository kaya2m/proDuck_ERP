using proDuck.Application;
using proDuck.Infrastructure;
using proDuck.Infrastructure.Filters;
using proDuck.Infrastructure.Services.Storage.Azure;
using proDuck.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;

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

        builder.Services.AddControllers(options => options.Filters.Add<ValidationFilters>())
            .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer("Admin", options => options.TokenValidationParameters = new()
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidAudience = builder.Configuration["Token:Audience"],
                ValidIssuer = builder.Configuration["Token:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
            });
        builder.Services.AddCors(opt => opt.AddDefaultPolicy(poilcy => poilcy
        .WithOrigins("http://localhost:4200", "https://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()));
        builder.Services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "1.0.1",
                Description = "<h1>proDuck ERP API</h1>\r\n<p>proDuck ERP API, bir DuckSolution ürünüdür...</p>",
                Extensions = new Dictionary<string, IOpenApiExtension>
        {
            { "proDuck", new OpenApiObject
                {
                    { "url", new OpenApiString("https://example.com/logo.png") },
                    { "altText", new OpenApiString("proDuck Logo") }
                }
            }
        }
            });
            s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });
            s.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
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
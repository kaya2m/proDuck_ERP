using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using System.Text;

namespace proDuck.WebApi.Configuration
{
    public static class ServicesExtensions
    {
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer("Admin", options => options.TokenValidationParameters = new()
           {
               ValidateAudience = true,
               ValidateIssuer = true,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,

               ValidAudience = configuration["Token:Audience"],
               ValidIssuer = configuration["Token:Issuer"],
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]))
           });
        }
        public static void ConfigureSwaggerSetting(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
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
        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(opt => opt.AddDefaultPolicy(poilcy => poilcy
            .WithOrigins("http://localhost:4200", "https://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()));
        }
    }
}

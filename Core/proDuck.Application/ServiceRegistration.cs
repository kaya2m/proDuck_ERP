using proDuck.Application.Abstraction.Token;
using proDuck.Application.DTOs;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            collection.AddHttpClient();
        }
    }
}

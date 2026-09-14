using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace E_Commerce_WebApplication.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));



            return services;
        }

    }
}

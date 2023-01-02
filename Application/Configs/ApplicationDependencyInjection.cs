using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configs
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection InjectApplicationDependecies (this IServiceCollection services)
        {
            services.AddScoped<IProductsServices, ProductsServices>();

            return services;
        }
    }
}

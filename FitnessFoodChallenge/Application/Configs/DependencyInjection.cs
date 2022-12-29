using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configs
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectDependecies (this IServiceCollection services)
        {
            services.AddScoped<IProductsServices, ProductsServices>();

            return services;
        }
    }
}

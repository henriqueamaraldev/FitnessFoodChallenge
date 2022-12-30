using Microsoft.Extensions.DependencyInjection;
using Repository.Models.Interfaces;
using Repository.services;

namespace Application.Configs
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection InjectRepositoryDependecies(this IServiceCollection services)
        {
            services.AddScoped<IProductsCollection, ProductsCollection>();

            return services;
        }
    }
}
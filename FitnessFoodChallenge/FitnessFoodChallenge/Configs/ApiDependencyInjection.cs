using Application.Interfaces;
using Application.Services;
using FitnessFoodChallenge.Api.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Logging;

namespace FitnessFoodChallenge.Api.Configs
{
    public static class ApiDependencyInjection
    {
        public static IServiceCollection InjectApplicationDependecies(this IServiceCollection services)
        {
            services.AddScoped<ILogger<ProductsController>, Logger<ProductsController>>();

            return services;
        }
    }
}
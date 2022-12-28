using Cron.Service.services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Cron.Service.configs
{
    public static class CronAdapter
    {
        public static IServiceCollection AddCronAdapter(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddQuartz(quartz =>
                {
                    quartz.UseMicrosoftDependencyInjectionJobFactory();
                    quartz.AddJobAndTrigger<OpenFoodFactsCron>(configuration);
                }
            );

            return services;
        }
    }
}

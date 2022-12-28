using Cron.Service.models;
using Microsoft.Extensions.Configuration;
using Quartz;

namespace Cron.Service.configs
{
    public static class QuartzAdapater
    {
        public static void AddJobAndTrigger<T>(
                this IServiceCollectionQuartzConfigurator quartz, 
                IConfiguration config
            )
            where T : IJob
        {
            string jobName = typeof(T).Name;

            var configKey = $"Quartz: {jobName}";
            var cronExecutionTime = config[configKey];

            if (string.IsNullOrEmpty(cronExecutionTime))
            {
                throw new Exception($"Quartz schedule config not found.");
            }

            var jobKey = new JobKey(jobName);

            
            quartz.AddJob<T>(options => options.WithIdentity(jobKey));

            quartz.AddTrigger(options => options
                .ForJob(jobKey)
                .WithIdentity(jobName + "-trigger")
                .WithCronSchedule(cronExecutionTime)
            );
        }

        //Methods for refactoring
        public static void AddJob<T>(
                IServiceCollectionQuartzConfigurator quartz, 
                JobKey jobKey
            )
            where T : IJob
        {
            quartz.AddJob<T>(options => options.WithIdentity(jobKey));
        }

        public static void AddTrigger(IServiceCollectionQuartzConfigurator quartz, JobModel job)
        {
            quartz.AddTrigger(options => options
               .ForJob(job.Key)
               .WithIdentity(job.Name + "-trigger")
               .WithCronSchedule(job.ExecutionTime)
           );
        }
    }
}

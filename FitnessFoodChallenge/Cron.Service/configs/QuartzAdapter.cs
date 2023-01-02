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

            var cronExecutionTime = config.GetSection(jobName).Value;

            if (string.IsNullOrEmpty(cronExecutionTime))
            {
                throw new Exception($"Quartz schedule config not found.");
            }

            var jobKey = new JobKey(jobName);

            quartz = AddJob<T>(quartz, jobKey);

            JobModel job = new(jobKey, jobName, cronExecutionTime);

            quartz = AddTrigger(quartz, job);
        }

        
        public static IServiceCollectionQuartzConfigurator AddJob<T>(
                IServiceCollectionQuartzConfigurator quartz, 
                JobKey jobKey
            )
            where T : IJob
        {
            quartz.AddJob<T>(options => options.WithIdentity(jobKey));
            return quartz;
        }

        public static IServiceCollectionQuartzConfigurator AddTrigger(IServiceCollectionQuartzConfigurator quartz, JobModel job)
        {
            quartz.AddTrigger(options => options
               .ForJob(job.Key)
               .WithIdentity(job.Name + "-trigger")
               .WithCronSchedule(job.ExecutionTime)
           );

            return quartz;
        }
    }
}

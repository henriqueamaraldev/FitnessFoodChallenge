using Quartz;

namespace Cron.Service.models
{
    public class JobModel
    {
        public JobKey Key;
        public string Name;
        public string ExecutionTime;
        public JobModel(JobKey jobKey, string jobName, string jobExecutionTime)
        {
            this.Key = jobKey;
            this.Name = jobName;
            this.ExecutionTime = jobExecutionTime;
        }
    }
}

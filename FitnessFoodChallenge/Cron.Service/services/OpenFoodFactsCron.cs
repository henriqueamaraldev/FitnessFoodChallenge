using Microsoft.Extensions.Logging;
using Quartz;

namespace Cron.Service.services
{
    public class OpenFoodFactsCron : IJob
    {
        private readonly ILogger<OpenFoodFactsCron> _logger;
        public OpenFoodFactsCron(ILogger<OpenFoodFactsCron> logger)
        {
            _logger = logger;
        }
        public Task Execute(IJobExecutionContext context)
        {
            throw new Exception();

            /*
            {
                return Task.CompletedTask;
                throw new Exception();
                
            }
            catch (Exception e)
            {
                _logger.LogError("FoodJob error", e);
            }*/
        }
    }
}

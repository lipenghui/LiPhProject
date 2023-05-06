namespace LiPhProject.定时服务.JobTimer
{
    public class WorkService1 : BackgroundService
    {
        private readonly ILogger<WorkService1> _logger;
        public WorkService1(ILogger<WorkService1> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("runing at:{time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

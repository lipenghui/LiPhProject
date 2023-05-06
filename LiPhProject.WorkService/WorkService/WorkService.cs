namespace LiPhProject.WorkService
{
    public class WorkService : BackgroundService
    {
        private readonly ILogger<WorkService> _logger;
        public WorkService(ILogger<WorkService> logger)
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

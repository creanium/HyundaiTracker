using HyundaiTracker.Core.Interfaces;

namespace HyundaiTracker.Worker;

public class Worker(ILogger<Worker> logger, IEntryPointService entryPointService) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation("Worker running at: {Time}", DateTimeOffset.Now);
            }

            await entryPointService.ExecuteAsync();

            await Task.Delay(1000, stoppingToken);
        }
    }
}

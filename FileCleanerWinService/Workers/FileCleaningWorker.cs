namespace FileCleanerWinService.Workers;

internal sealed class FileCleaningWorker : BackgroundService
{
    private readonly IDefinitions _definitions;
    private readonly ILogger<FileCleaningWorker> _logger;

    public FileCleaningWorker(
        IDefinitions definitions,
        ILogger<FileCleaningWorker> logger)
    {
        this._definitions = definitions;
        this._logger = logger;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation($"Starting {Constants.ServiceName} at {DateTime.UtcNow.ToLongTimeString()}");

        try
        {
            foreach (var path in _definitions.PathFilesFilter)
            {
                var patterns = path.Patterns!.Split(',');

                var filesToDelete = Directory.EnumerateFiles(path.Path!)
                                             .Where(file => patterns.Any(p => file.Contains(p.Trim(), StringComparison.CurrentCultureIgnoreCase)))
                                             .ToList();

                filesToDelete.ForEach(File.Delete); 
            }                            
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"{Constants.ServiceName} failed: {ex.Message}");
            Environment.Exit(999);            
        }
        finally
        {
            _logger.LogInformation($"Finishing {Constants.ServiceName} at {DateTime.UtcNow.ToLongTimeString()}");
        }

        return Task.CompletedTask;
    }
}
await Host.CreateDefaultBuilder()
.UseWindowsService(config =>
{
    config.ServiceName = Constants.ServiceName;
})
.ConfigureServices(services =>
{
    services.AddSingleton(_ => Definitions.CreateAsync().GetAwaiter().GetResult() as IDefinitions);
    services.AddHostedService<FileCleaningWorker>();
})
.Build()
.RunAsync();
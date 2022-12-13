namespace FileCleanerWinService.Data;

internal sealed record Definitions : IDefinitions
{
    public IReadOnlyCollection<PathFileKeyValue> PathFilesFilter { get; }

    public Definitions(IReadOnlyCollection<PathFileKeyValue> pathFileKeyValues)
    {
        this.PathFilesFilter = pathFileKeyValues;
    }

    public static async Task<Definitions> CreateAsync()
    {
        var pathFilesKeyValues = JsonSerializer.Deserialize<IEnumerable<PathFileKeyValue>>(
            await File.ReadAllTextAsync(Constants.DefinitionsPath));

        _ = pathFilesKeyValues ?? throw new Exception($"{nameof(pathFilesKeyValues)} cannot be empty");

        return new Definitions(pathFilesKeyValues.ToList().AsReadOnly());
    }
}
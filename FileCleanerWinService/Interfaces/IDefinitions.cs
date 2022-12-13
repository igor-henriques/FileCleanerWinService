namespace FileCleanerWinService.Interfaces
{
    internal interface IDefinitions
    {
        IReadOnlyCollection<PathFileKeyValue> PathFilesFilter { get; }
    }
}
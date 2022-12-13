namespace FileCleanerWinService.Models;

internal record struct PathFileKeyValue
{
    public string? Path { get; init; }
    public string? Patterns { get; init; }
}
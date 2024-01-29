namespace QuoteSearch.Facades;

public interface IConsole
{
    void WriteLine(string message);
    string? ReadLine();
}
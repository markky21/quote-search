namespace QuoteSearch.Facades;

public class ConsoleFacade : IConsole
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public string? ReadLine()
    {
        return Console.ReadLine();
    }
}

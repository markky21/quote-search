namespace QuoteSearch.Controller;

public record SearchResult(bool Success, string Message)
{
    public override string ToString()
    {
        return Message;
    }
}
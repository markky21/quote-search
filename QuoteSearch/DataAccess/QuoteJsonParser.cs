using Newtonsoft.Json;
using QuoteSearch.Models;

namespace QuoteSearch.DataAccess;

public class QuoteJsonParser
{
    public static IReadOnlyList<Datum> ParseQuotes(string message)
    {
        var root = JsonConvert.DeserializeObject<QuotesResponse>(message);
        return root?.Data == null ? Array.Empty<Datum>() : root!.Data;
    }
}
using QuoteSearch.Models;

namespace QuoteSearch.DataAccess;

public class QuoteRepository(HttpClient httpClient) : IQuoteRepository
{
    private readonly string _apiUrl = "https://quote-garden.onrender.com/api/v3";
    private readonly HttpClient _httpClient = httpClient;

    public async Task<IReadOnlyList<Datum>> GetQuotes(GetQuotesParams quotesParams)
    {
        var contentMessage = await FetchQuotes(quotesParams);
        return QuoteJsonParser.ParseQuotes(contentMessage);
    }

    private async Task<string> FetchQuotes(GetQuotesParams quotesParams)
    {
        var url = $"{_apiUrl}/quotes?{quotesParams}";
        var httpResponseMessage = await _httpClient.GetAsync(url);
        httpResponseMessage.EnsureSuccessStatusCode();
        return await httpResponseMessage.Content.ReadAsStringAsync();
    }
}
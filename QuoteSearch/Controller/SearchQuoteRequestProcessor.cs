using QuoteSearch.DataAccess;
using QuoteSearch.Models;

namespace QuoteSearch.Controller;

public class SearchQuoteRequestProcessor(IQuoteRepository quoteRepository) : ISearchQuoteRequestProcessor
{
    private readonly IQuoteRepository _quoteRepository = quoteRepository;

    public async Task<SearchResult> Process(SearchParams searchParams)
    {
        var getQuotesParams = new GetQuotesParams(searchParams.Query, searchParams.Page, searchParams.Limit);
        var quotes = await _quoteRepository.GetQuotes(getQuotesParams);
        var datum = QuoteInListFinder.Find(quotes, searchParams.Query);
        return PrepareSearchResult(datum);
    }

    private static SearchResult PrepareSearchResult(Datum? datum)
    {
        return datum?.QuoteText.Length > 0
            ? new SearchResult(true, datum.QuoteText)
            : new SearchResult(false, "No quotes found");
    }
}
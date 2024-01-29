namespace QuoteSearch.Controller;

public interface ISearchQuoteRequestProcessor
{
    Task<SearchResult> Process(SearchParams searchParams);
}
namespace QuoteSearch.Controller;

public interface ISearchQuoteProcessor
{
    SearchResult[] ProcessSequential(SearchParams searchParams);
    Task<SearchResult[]> ProcessParallel(SearchParams searchParams);
}
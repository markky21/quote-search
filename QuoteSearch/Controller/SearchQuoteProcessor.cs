namespace QuoteSearch.Controller;

public class SearchQuoteProcessor(ISearchQuoteRequestProcessor searchQuoteRequestProcessor) : ISearchQuoteProcessor
{
    private readonly ISearchQuoteRequestProcessor _searchQuoteRequestProcessor = searchQuoteRequestProcessor;

    public SearchResult[] ProcessSequential(SearchParams searchParams)
    {
        return Enumerable.Range(0, searchParams.Page)
            .Select(page => ProcessSearchOnPage(searchParams, page).Result)
            .ToArray();
    }

    public async Task<SearchResult[]> ProcessParallel(SearchParams searchParams)
    {
        var tasks = Enumerable.Range(0, searchParams.Page)
            .Select(page => ProcessSearchOnPage(searchParams, page));

        return await Task.WhenAll(tasks);
    }

    private Task<SearchResult> ProcessSearchOnPage(SearchParams searchParams, int page)
    {
        var newSearchParams = new SearchParams(searchParams.Query, page + 1, searchParams.Limit);
        return _searchQuoteRequestProcessor.Process(newSearchParams);
    }
}
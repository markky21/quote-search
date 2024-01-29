// See https://aka.ms/new-console-template for more information

using QuoteSearch.Controller;
using QuoteSearch.DataAccess;
using QuoteSearch.Facades;
using QuoteSearch.View;

try
{
    var userInteractor = new ConsoleUserInteractor(new ConsoleFacade());
    using var httpClient = new HttpClient();
    var quoteSearchApp = new QuoteSearchApp(
        new UserSearchRequestGenerator(
            userInteractor),
        new SearchQuoteProcessor(
            new SearchQuoteRequestProcessor(
                new QuoteRepository(
                    httpClient))),
        new QuoteSearchPresenter(userInteractor)
    );
    await quoteSearchApp.Main();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

internal class QuoteSearchApp(
    IUserSearchRequestGenerator userSearchRequestGenerator,
    ISearchQuoteProcessor searchQuoteProcessor,
    IQuoteSearchPresenter quoteSearchPresenter)
{
    private readonly IQuoteSearchPresenter _quoteSearchPresenter = quoteSearchPresenter;
    private readonly ISearchQuoteProcessor _searchQuoteProcessor = searchQuoteProcessor;
    private readonly IUserSearchRequestGenerator _userSearchRequestGenerator = userSearchRequestGenerator;

    public async Task Main()
    {
        var searchConfig = _userSearchRequestGenerator.AskUserForSearchConfiguration();

        SearchParams searchParams = new(
            searchConfig.SearchString,
            searchConfig.SearchInPages,
            searchConfig.QuotesPerPage);
        var searchResult = searchConfig.IsProcessingParallel
            ? await _searchQuoteProcessor.ProcessParallel(searchParams)
            : _searchQuoteProcessor.ProcessSequential(searchParams);

        _quoteSearchPresenter.Print(searchResult);
    }
}
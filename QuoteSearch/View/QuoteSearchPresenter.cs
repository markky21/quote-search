using QuoteSearch.Controller;

namespace QuoteSearch.View;

public class QuoteSearchPresenter(IUserInteractor userInteractor) : IQuoteSearchPresenter
{
    private readonly IUserInteractor _userInteractor = userInteractor;

    public void Print(SearchResult[] searchResult)
    {
        foreach (var result in searchResult) _userInteractor.Print(result + Environment.NewLine);
    }
}
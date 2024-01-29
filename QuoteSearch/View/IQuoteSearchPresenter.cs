using QuoteSearch.Controller;

namespace QuoteSearch.View;

public interface IQuoteSearchPresenter
{
    void Print(SearchResult[] searchResult);
}
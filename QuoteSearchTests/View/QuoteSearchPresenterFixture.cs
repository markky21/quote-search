using QuoteSearch.Facades;
using QuoteSearch.View;

namespace QuoteSearchTests.View;

public static class QuoteSearchPresenterFixture
{
    public static QuoteSearchPresenter Create()
    {
        return new QuoteSearchPresenter(ConsoleUserInteractorFixture.Create());
    }

    public static QuoteSearchPresenter Create(IConsole console)
    {
        return new QuoteSearchPresenter(ConsoleUserInteractorFixture.Create(console));
    }
}
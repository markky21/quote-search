using Moq;
using QuoteSearch.Facades;
using QuoteSearch.View;

namespace QuoteSearchTests.View;

public static class ConsoleUserInteractorFixture
{
    public static ConsoleUserInteractor Create()
    {
        var mockConsole = new Mock<IConsole>();
        return Create(mockConsole.Object);
    }

    public static ConsoleUserInteractor Create(IConsole console)
    {
        return new ConsoleUserInteractor(console);
    }
}
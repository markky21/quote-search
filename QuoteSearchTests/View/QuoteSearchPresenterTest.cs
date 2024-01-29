using Moq;
using QuoteSearch.Controller;
using QuoteSearch.Facades;
using QuoteSearch.View;

namespace QuoteSearchTests.View;

[TestFixture]
[TestOf(typeof(QuoteSearchPresenter))]
public class QuoteSearchPresenterTest
{
    [SetUp]
    public void Setup()
    {
        _mockConsole = new Mock<IConsole>();
        _sut = QuoteSearchPresenterFixture.Create(_mockConsole.Object);
    }

    private Mock<IConsole> _mockConsole;
    private QuoteSearchPresenter _sut;

    [Test]
    public void Print_search_result_to_the_console()
    {
        var searchResult = new[]
        {
            new SearchResult(true, "First quote"),
            new SearchResult(true, "Second quote"),
            new SearchResult(false, "Not found")
        };
        _sut.Print(searchResult);

        _mockConsole.Verify(x => x.WriteLine("First quote" + Environment.NewLine));
        _mockConsole.Verify(x => x.WriteLine("Second quote" + Environment.NewLine));
        _mockConsole.Verify(x => x.WriteLine("Not found" + Environment.NewLine));
    }
}
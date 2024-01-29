using Moq;
using QuoteSearch.Facades;
using QuoteSearchTests.Controller;
using QuoteSearchTests.View;

namespace QuoteSearchTests;

[TestFixture]
[TestOf(typeof(QuoteSearchApp))]
public class QuoteSearchAppTest
{
    [SetUp]
    public void SetUp()
    {
        _mockConsole = new Mock<IConsole>();
        var searchQuoteProcessor = SearchQuoteProcessorFixture.Create();
        var userSearchRequestGenerator = UserSearchRequestGeneratorFixture.Create(_mockConsole.Object);
        var quoteSearchPresenter = QuoteSearchPresenterFixture.Create(_mockConsole.Object);
        _sut = new QuoteSearchApp(
            userSearchRequestGenerator,
            searchQuoteProcessor,
            quoteSearchPresenter
        );
    }

    private QuoteSearchApp _sut;
    private Mock<IConsole> _mockConsole;

    [Test]
    public async Task Show_user_quotes()
    {
        UserSearchRequestGeneratorFixture.SetupSequenceUserAnswers(_mockConsole);

        await _sut.Main();

        _mockConsole.Verify(x => x.WriteLine("Test Quote" + Environment.NewLine));
    }
}
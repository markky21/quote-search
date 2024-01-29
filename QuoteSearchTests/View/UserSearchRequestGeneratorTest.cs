using Moq;
using QuoteSearch;
using QuoteSearch.Facades;
using QuoteSearch.View;

namespace QuoteSearchTests.View;

[TestFixture]
[TestOf(typeof(UserSearchRequestGenerator))]
public class UserSearchRequestGeneratorTest
{
    [SetUp]
    public void SetUp()
    {
        _mockConsole = new Mock<IConsole>();
        _sut = UserSearchRequestGeneratorFixture.Create(_mockConsole.Object);
    }

    private UserSearchRequestGenerator _sut;
    private Mock<IConsole> _mockConsole;

    [Test]
    public void On_start_ask_user_for_word_to_search()
    {
        UserSearchRequestGeneratorFixture.SetupSequenceUserAnswers(_mockConsole);

        _sut.AskUserForSearchConfiguration();

        _mockConsole.Verify(x => x.WriteLine("Enter a word to search:"));
    }

    [Test]
    public void Ask_user_for_search_should_be_done_in_parallel()
    {
        UserSearchRequestGeneratorFixture.SetupSequenceUserAnswers(_mockConsole);

        _sut.AskUserForSearchConfiguration();

        _mockConsole.Verify(x => x.WriteLine("Should processing of the downloaded data be performed in parallel?"));
    }

    [Test]
    public void Return_search_config()
    {
        UserSearchRequestGeneratorFixture.SetupSequenceUserAnswers(_mockConsole);

        var result = _sut.AskUserForSearchConfiguration();

        Assert.That(result, Is.EqualTo(new SearchConfig("test", 1, 100, true)));
    }
}
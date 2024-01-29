using Moq;
using QuoteSearch.Facades;
using QuoteSearch.View;

namespace QuoteSearchTests.View;

public static class UserSearchRequestGeneratorFixture
{
    public static UserSearchRequestGenerator Create()
    {
        return new UserSearchRequestGenerator(ConsoleUserInteractorFixture.Create());
    }

    public static UserSearchRequestGenerator Create(IConsole console)
    {
        return new UserSearchRequestGenerator(ConsoleUserInteractorFixture.Create(console));
    }

    public static void SetupSequenceUserAnswers(Mock<IConsole> mockConsole)
    {
        mockConsole.SetupSequence(x => x.ReadLine()).Returns("test").Returns("1").Returns("100").Returns("true");
    }
}
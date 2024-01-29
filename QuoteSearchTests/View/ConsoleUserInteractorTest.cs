using Moq;
using QuoteSearch.Facades;
using QuoteSearch.View;

namespace QuoteSearchTests.View;

[TestFixture]
[TestOf(typeof(ConsoleUserInteractor))]
public class ConsoleUserInteractorTest
{
    [SetUp]
    public void SetUp()
    {
        _consoleMock = new Mock<IConsole>();
        _cut = ConsoleUserInteractorFixture.Create(_consoleMock.Object);
    }

    private Mock<IConsole> _consoleMock;
    private ConsoleUserInteractor _cut;

    [Test]
    public void Write_to_console()
    {
        var message = "Test message";

        _cut.Print(message);

        _consoleMock.Verify(c => c.WriteLine(message), Times.Once);
    }

    [Test]
    public void Return_string_input_from_user()
    {
        var input = "Test input";
        _consoleMock.Setup(c => c.ReadLine()).Returns(input);

        var result = _cut.ReadString();

        Assert.That(result, Is.EqualTo(input));
    }

    [Test]
    public void Prompt_message_until_non_null_input()
    {
        _consoleMock.SetupSequence(c => c.ReadLine())
            .Returns(string.Empty)
            .Returns("Valid input");

        var result = _cut.ReadString();

        Assert.That(result, Is.EqualTo("Valid input"));
        _consoleMock.Verify(c => c.WriteLine("Input cannot be empty. Please try again."), Times.Exactly(1));
    }

    [Test]
    public void Return_number_input_from_user()
    {
        var input = "123";
        _consoleMock.Setup(c => c.ReadLine()).Returns(input);

        var result = _cut.ReadInt();

        Assert.That(result, Is.EqualTo(int.Parse(input)));
    }

    [Test]
    public void Prompt_message_until_valid_intiger()
    {
        _consoleMock.SetupSequence(c => c.ReadLine())
            .Returns("not an integer")
            .Returns("123");

        var result = _cut.ReadInt();

        Assert.That(result, Is.EqualTo(123));
        _consoleMock.Verify(c => c.WriteLine("Invalid input. Please enter a valid integer."), Times.Exactly(1));
    }

    [TestCase("yes", true)]
    [TestCase("true", true)]
    [TestCase("y", true)]
    [TestCase("t", true)]
    [TestCase("1", true)]
    [TestCase("no", false)]
    [TestCase("n", false)]
    [TestCase("false", false)]
    [TestCase("f", false)]
    [TestCase("0", false)]
    public void Return_bool_input_from_user(string input, bool expected)
    {
        _consoleMock.Setup(c => c.ReadLine()).Returns(input);

        var result = _cut.ReadBool();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Prompt_message_until_valid_bool()
    {
        _consoleMock.SetupSequence(c => c.ReadLine())
            .Returns("not a boolean")
            .Returns("yes");

        var result = _cut.ReadBool();

        Assert.That(result, Is.EqualTo(true));
        _consoleMock.Verify(c => c.WriteLine("Invalid input. Please enter a valid boolean (yes/no or true/false)."),
            Times.Exactly(1));
    }
}

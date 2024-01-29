using QuoteSearch.Facades;

namespace QuoteSearch.View;

public class ConsoleUserInteractor(IConsole console) : IUserInteractor
{
    private readonly IConsole _console = console;

    public void Print(string message)
    {
        _console.WriteLine(message);
    }

    public string ReadString()
    {
        string input;
        do
        {
            input = _console.ReadLine()!;
            if (string.IsNullOrEmpty(input)) _console.WriteLine("Input cannot be empty. Please try again.");
        } while (string.IsNullOrEmpty(input));

        return input;
    }


    public int ReadInt()
    {
        int result;
        var input = ReadString();
        while (!int.TryParse(input, out result))
        {
            _console.WriteLine("Invalid input. Please enter a valid integer.");
            input = ReadString();
        }

        return result;
    }

    public bool ReadBool()
    {
        while (true)
        {
            var input = ReadString().Trim().ToLower();

            switch (input)
            {
                case "yes" or "y" or "true" or "t" or "1":
                    return true;
                case "no" or "n" or "false" or "f" or "0":
                    return false;
                default:
                    _console.WriteLine("Invalid input. Please enter a valid boolean (yes/no or true/false).");
                    break;
            }
        }
    }
}

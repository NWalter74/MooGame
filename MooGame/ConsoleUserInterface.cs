namespace MooGame;

internal class ConsoleUserInterface : IUserInterface
{
    public string GetUserName()
    {
        Console.WriteLine("Enter your user name:");
        return Console.ReadLine();
    }

    public string GetGuess()
    {
        Console.WriteLine("Enter your guess (4-digit number):");
        string input = Console.ReadLine();

        while (!IsValidGuess(input))
        {
            Console.WriteLine("Invalid input. Please enter a 4-digit number:");
            input = Console.ReadLine();
        }

        return input;
    }

    public bool ShouldExit(string answer)
    {
        return !string.IsNullOrEmpty(answer) && answer.Substring(0, 1) == "n";
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    private bool IsValidGuess(string input)
    {
        if (input.Length != 4)
            return false;

        foreach (char c in input)
        {
            if (!char.IsDigit(c))
                return false;
        }

        return true;
    }
}

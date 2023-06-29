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
        return Console.ReadLine();
    }

    public bool ShouldExit(string answer)
    {
        return !string.IsNullOrEmpty(answer) && answer.Substring(0, 1) == "n";
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}

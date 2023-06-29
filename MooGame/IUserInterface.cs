namespace MooGame;

public interface IUserInterface
{
    string GetUserName();
    string GetGuess();
    bool ShouldExit(string answer);
    void ShowMessage(string message);
}

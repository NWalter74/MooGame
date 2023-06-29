namespace MooGame;

public interface IGame
{
    string GenerateGoal();
    string CheckBC(string goal, string guess);
    bool IsCorrectGuess(string bbcc);
}

namespace MooGame;

public class MastermindGame : IGame
{
    private GoalGenerator goalGenerator;
    private MastermindChecker mastermindChecker;

    public MastermindGame(GoalGenerator goalGenerator, MastermindChecker mastermindChecker)
    {
        this.goalGenerator = goalGenerator;
        this.mastermindChecker = mastermindChecker;
    }

    public string CheckBC(string goal, string guess)
    {
        return mastermindChecker.CheckMastermind(goal, guess);
    }

    public string GenerateGoal()
    {
        return goalGenerator.GenerateGoal();
    }

    public bool IsCorrectGuess(string result)
    {
        return mastermindChecker.IsCorrectGuess(result);
    }
}

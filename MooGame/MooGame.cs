namespace MooGame;

public class MooGame : IGame
{
    private GoalGenerator goalGenerator;
    private BullsAndCowsChecker bullsAndCowsChecker;

    public MooGame(GoalGenerator goalGenerator, BullsAndCowsChecker bullsAndCowsChecker)
    {
        this.goalGenerator = goalGenerator;
        this.bullsAndCowsChecker = bullsAndCowsChecker;
    }

    public string GenerateGoal()
    {
        return goalGenerator.GenerateGoal();
    }

    public string CheckBC(string goal, string guess)
    {
        return bullsAndCowsChecker.CheckBC(goal, guess);
    }

    public bool IsCorrectGuess(string bbcc)
    {
        return bullsAndCowsChecker.IsCorrectGuess(bbcc);
    }
}

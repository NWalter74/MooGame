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

    //public string GenerateGoal()
    //{
    //    Random randomGenerator = new Random();
    //    string goal = "";
    //    for (int i = 0; i < 4; i++)
    //    {
    //        int random = randomGenerator.Next(10);
    //        string randomDigit = "" + random;
    //        while (goal.Contains(randomDigit))
    //        {
    //            random = randomGenerator.Next(10);
    //            randomDigit = "" + random;
    //        }
    //        goal = goal + randomDigit;
    //    }
    //    return goal;
    //}

    //public string CheckBC(string goal, string guess)
    //{
    //    int cows = 0, bulls = 0;
    //    guess += "    ";
    //    for (int i = 0; i < 4; i++)
    //    {
    //        for (int j = 0; j < 4; j++)
    //        {
    //            if (goal[i] == guess[j])
    //            {
    //                if (i == j)
    //                {
    //                    bulls++;
    //                }
    //                else
    //                {
    //                    cows++;
    //                }
    //            }
    //        }
    //    }
    //    return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
    //}

    //public bool IsCorrectGuess(string bbcc)
    //{
    //    return bbcc == "BBBB,";
    //}
}

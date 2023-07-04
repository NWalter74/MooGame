namespace MooGame;

public class BullsAndCowsChecker
{
    /// <summary>
    /// Checks the number of bulls and cows in the guess compared to the goal.
    /// </summary>
    /// <param name="goal">The goal number</param>
    /// <param name="guess">The guessed number</param>
    /// <returns>A string representation of the number of bulls and cows.</returns>
    public string CheckBC(string goal, string guess)
    {
        int cows = 0, bulls = 0;
        guess += "    ";
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (goal[i] == guess[j])
                {
                    if (i == j)
                    {
                        bulls++;
                    }
                    else
                    {
                        cows++;
                    }
                }
            }
        }
        return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
    }

    /// <summary>
    /// Checks if the number of bulls and cows represents a correct guess.
    /// </summary>
    /// <param name="bbcc">The string representation of the number of bulls and cows.</param>
    /// <returns>True if the game is correct. False otherwise.</returns>
    public bool IsCorrectGuess(string bbcc)
    {
        return bbcc == "BBBB,";
    }
}

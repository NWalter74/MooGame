namespace MooGame;

public class MastermindChecker
{
    public string CheckMastermind(string goal, string guess)
    {
        int correctPositions = 0, correctColors = 0;

        for (int i = 0; i < 4; i++)
        {
            if (goal[i] == guess[i])
            {
                correctPositions++;
            }
            else if (goal.Contains(guess[i].ToString()))
            {
                correctColors++;
            }
        }

        return $"\n({correctPositions}) Correct Positions, ({correctColors}) Correct Colors";
    }

    public bool IsCorrectGuess(string result)
    {
        return result == "\n(4) Correct Positions, (0) Correct Colors";
    }
}

namespace MooGame;

public class GoalGenerator
{
    private Random randomGenerator;

    public GoalGenerator()
    {
        randomGenerator = new Random();
    }

    /// <summary>
    /// Generates a random 4-digit goal number.
    /// </summary>
    /// <returns>The generated goal number.</returns>
    public string GenerateGoal()
    {
        string goal = "";
        for (int i = 0; i < 4; i++)
        {
            int random = randomGenerator.Next(10);
            string randomDigit = "" + random;
            while (goal.Contains(randomDigit))
            {
                random = randomGenerator.Next(10);
                randomDigit = "" + random;
            }
            goal = goal + randomDigit;
        }
        return goal;
    }
}

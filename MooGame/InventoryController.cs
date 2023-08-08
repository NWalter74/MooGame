using System.Diagnostics.Metrics;

namespace MooGame;

public class InventoryController
{
    private readonly IUserInterface userInterface;
    private IGame game;
    private readonly IStatisticsCollector statisticsCollector;

    public IGame Game
    {
        get { return game; }
        set { game = value; }
    }

    public InventoryController(IUserInterface userInterface, IGame game, IStatisticsCollector statisticsCollector)
    {
        this.userInterface = userInterface;
        this.game = game;
        this.statisticsCollector = statisticsCollector;
    }

    public void Run()
    {
        bool playOn = true;
        string name = userInterface.GetUserName();

        while (playOn)
        {
            string goal = game.GenerateGoal();

            userInterface.ShowMessage("New game:");

            userInterface.ShowMessage("For practice, number is: " + goal);

            string guess = userInterface.GetGuess();
            int nGuess = 1;
            string result = game.CheckBC(goal, guess);
            userInterface.ShowMessage(result);

            while (!game.IsCorrectGuess(result))
            {
                nGuess++;
                guess = userInterface.GetGuess();
                result = game.CheckBC(goal, guess);
                userInterface.ShowMessage(result);
            }

            statisticsCollector.SavePlayerData(name, nGuess);
            List<PlayerData> results = statisticsCollector.LoadPlayerData();
            statisticsCollector.ShowTopList(results);

            Console.WriteLine("Congratulations! You guessed the number in " + nGuess + " attempts.");

            Console.WriteLine("Continue? (Type 'y' to continue or 'n' to exit)");

            string answer = Console.ReadLine();

            if (userInterface.ShouldExit(answer))
            {
                playOn = false;
            }
        }
    }
}
namespace MooGame;

internal class InventoryController
{
    private readonly IUserInterface userInterface;
    private readonly IGame game;
    private readonly IStatisticsCollector statisticsCollector;

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
            string goal = game.GenerateGoal();  //springt nach MooGame

            userInterface.ShowMessage("New game:");

            // Comment out or remove the next line to play real games!
            userInterface.ShowMessage("For practice, number is: " + goal);

            string guess = userInterface.GetGuess();
            int nGuess = 1;
            string bbcc = game.CheckBC(goal, guess);
            userInterface.ShowMessage(bbcc);

            while (!game.IsCorrectGuess(bbcc))
            {
                nGuess++;
                guess = userInterface.GetGuess();
                userInterface.ShowMessage(guess);
                bbcc = game.CheckBC(goal, guess);
                userInterface.ShowMessage(bbcc);
            }

            statisticsCollector.SavePlayerData(name, nGuess);
            List<PlayerData> results = statisticsCollector.LoadPlayerData();
            statisticsCollector.ShowTopList(results);

            Console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue?");

            string answer = userInterface.GetGuess();
            if (userInterface.ShouldExit(answer))
            {
                playOn = false;
            }
        }
    }
}

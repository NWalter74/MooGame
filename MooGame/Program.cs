namespace MooGame;

internal class Program
{
    static void Main(string[] args)
    {
        IUserInterface userInterface = new ConsoleUserInterface();
        IGame game = new MooGame(new GoalGenerator(), new BullsAndCowsChecker());
        IStatisticsCollector statisticsCollector = StatisticsCollector.GetInstance();

        InventoryController inventoryController = new InventoryController(userInterface, game, statisticsCollector);
        inventoryController.Run();
    }
}
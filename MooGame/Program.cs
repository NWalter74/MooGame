namespace MooGame;

internal class Program
{
    static void Main(string[] args)
    {
        IUserInterface userInterface = new ConsoleUserInterface();
        IGame mooGame = new MooGame(new GoalGenerator(), new BullsAndCowsChecker());
        IGame mastermindGame = new MastermindGame(new GoalGenerator(), new MastermindChecker());
        IStatisticsCollector statisticsCollector = StatisticsCollector.GetInstance();

        InventoryController inventoryController = new InventoryController(userInterface, mooGame, statisticsCollector);

        bool playOn = true;
        while (playOn)
        {
            Console.WriteLine("\nSelect a game:");
            Console.WriteLine("1. Moo Game");
            Console.WriteLine("2. Mastermind Game");
            Console.WriteLine("3. Exit");
            Console.WriteLine();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    inventoryController.Game = mooGame;
                    break;
                case "2":
                    inventoryController.Game = mastermindGame;
                    break;
                case "3":
                    playOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }

            if (playOn)
            {
                inventoryController.Run();
            }
        }
    }
}
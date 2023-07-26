namespace MooGame;

public class StatisticsCollector : IStatisticsCollector
{
    private static StatisticsCollector instance;

    private StatisticsCollector()
    {
    }

    public static StatisticsCollector GetInstance()
    {
        if (instance == null)
        {
            instance = new StatisticsCollector();
        }
        return instance;
    }

    public void SavePlayerData(string name, int nGuess)
    {
        using StreamWriter output = new("result.txt", append: true);
        output.WriteLine(name + "#&#" + nGuess);
    }

    public List<PlayerData> LoadPlayerData()
    {
        List<PlayerData> results = new();

        try
        {
            using StreamReader input = new("result.txt");
            string line;
            while ((line = input.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData pd = new(name, guesses);
                int pos = results.IndexOf(pd);
                if (pos < 0)
                {
                    results.Add(pd);
                }
                else
                {
                    results[pos].Update(guesses);
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("An error occurred while loading player data: " + ex.Message);
        }

        return results;
    }

    public void ShowTopList(List<PlayerData> results)
    {
        results.Sort((p1, p2) => p1.GetAverage().CompareTo(p2.GetAverage()));
        Console.WriteLine("Player   games average");
        foreach (PlayerData p in results)
        {
            Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.GetAverage()));
        }
    }
}

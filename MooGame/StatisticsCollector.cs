﻿namespace MooGame;

public class StatisticsCollector : IStatisticsCollector
{
    public void SavePlayerData(string name, int nGuess)
    {
        using (StreamWriter output = new StreamWriter("result.txt", append: true))
        {
            output.WriteLine(name + "#&#" + nGuess);
        }
    }

    public List<PlayerData> LoadPlayerData()
    {
        List<PlayerData> results = new List<PlayerData>();

        using (StreamReader input = new StreamReader("result.txt"))
        {
            string line;
            while ((line = input.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData pd = new PlayerData(name, guesses);
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
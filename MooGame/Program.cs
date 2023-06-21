using System;
using System.IO;
using System.Collections.Generic;

namespace MooGame;

internal class Program
{
    static void Main(string[] args)
    {
        bool playOn = true;
        Console.WriteLine("Enter your user name:\n");
        string name = Console.ReadLine();

        while (playOn)
        {
            string goal = GenerateGoal();


            Console.WriteLine("New game:\n");
            //comment out or remove next line to play real games!
            Console.WriteLine("For practice, number is: " + goal + "\n");
            string guess = Console.ReadLine();

            int nGuess = 1;
            string bbcc = CheckBC(goal, guess);
            Console.WriteLine(bbcc + "\n");
            while (!IsCorrectGuess(bbcc))
            {
                nGuess++;
                guess = Console.ReadLine();
                Console.WriteLine(guess + "\n");
                bbcc = CheckBC(goal, guess);
                Console.WriteLine(bbcc + "\n");
            }
            SavePlayerData(name, nGuess);
            ShowTopList();
            Console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue?");
            string answer = Console.ReadLine();
            if (ShouldExit(answer))
            {
                playOn = false;
            }
        }
    }

    static string GenerateGoal()
    {
        Random randomGenerator = new Random();
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

    static string CheckBC(string goal, string guess)
    {
        int cows = 0, bulls = 0;
        guess += "    ";     // if player entered less than 4 chars
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

    static void SavePlayerData(string name, int nGuess)
    {
        using (StreamWriter output = new StreamWriter("result.txt", append: true))
        {
            output.WriteLine(name + "#&#" + nGuess);
        }
    }

    static void ShowTopList()
    {
        List<PlayerData> results = LoadPlayerData();

        results.Sort((p1, p2) => p1.GetAverage().CompareTo(p2.GetAverage()));
        Console.WriteLine("Player   games average");
        foreach (PlayerData p in results)
        {
            Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.GetAverage()));
        }
    }

    static List<PlayerData> LoadPlayerData()
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

    static bool IsCorrectGuess(string bbcc)
    {
        return bbcc == "BBBB,";
    }

    static bool ShouldExit(string answer)
    {
        return !string.IsNullOrEmpty(answer) && answer.Substring(0, 1) == "n";
    }
}

class PlayerData
{
    public string Name { get; private set; }
    public int NGames { get; private set; }
    int totalGuess;


    public PlayerData(string name, int guesses)
    {
        this.Name = name;
        NGames = 1;
        totalGuess = guesses;
    }

    public void Update(int guesses)
    {
        totalGuess += guesses;
        NGames++;
    }

    public double GetAverage()
    {
        return (double)totalGuess / NGames;
    }


    public override bool Equals(Object p)
    {
        return Name.Equals(((PlayerData)p).Name);
    }


    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
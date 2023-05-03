Random rnd = new Random();

Console.WriteLine(rnd.NextDouble(50));

string[] words = { "apple", "banana", "mango", "cheese" };
Console.WriteLine(rnd.NextString(words));

Console.WriteLine(rnd.CoinFlip());

public static class RandomExtensions
{
    public static Random rnd = new Random();
    public static double NextDouble(this Random number, double max)
    {
        return rnd.NextDouble() * max;
    }

    public static string NextString(this Random wordArray, string[] words)
    {
        return words[rnd.Next(words.Length)];
    }

    public static bool CoinFlip(this Random face, double chance = 0.5)
    {
        double probability = rnd.NextDouble();
        if (rnd.NextDouble() < chance)
        {
            return true;
        }
        return false;
    }
}
Console.WriteLine("Please enter your name:");

string player = Console.ReadLine(); 
int score = 0;

if (File.Exists($"{player}.txt"))
{
    string oldScore = File.ReadAllText($"{player}.txt");
    Console.WriteLine($"Previous score: {oldScore}");
    score = Convert.ToInt32(oldScore);
}

while (Console.ReadKey().Key != ConsoleKey.Enter)
{
    score++;
    Console.WriteLine(score);
}

File.WriteAllText($"{player}.txt", score.ToString());
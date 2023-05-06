List<int> cookies = new List<int>();

Random rand = new Random();

Player p1 = new Player();
Player p2 = new Player();

Console.WriteLine("Enter a name for player 1:");
p1.name = Console.ReadLine();
Console.WriteLine("Enter a name for player 2");
p2.name = Console.ReadLine();

int randNum = rand.Next(10);

p1.turn = true;
int response = -1;

while (response != randNum)
{
    Player currentPlayer = p1.turn ? p1 : p2;
    try
    {
        Console.WriteLine($"{currentPlayer.name}'s turn");
        Console.WriteLine("Pick a number between 0 - 9");
        response = Convert.ToInt32(Console.ReadLine());

        if (response == randNum)
        {
            throw new Exception("uh oh");
        }

        if (p1.turn)
        {
            p1.turn = false;
            p2.turn = true;
        }
        else
        {
            p1.turn = true;
            p2.turn = false;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

struct Player
{
    public bool turn;

    public string name;

    public Player()
    {
        turn = false;
    }

}
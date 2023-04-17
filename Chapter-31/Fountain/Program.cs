using Fountain;

Game game = new Game();

while (true)
{
    Console.WriteLine("Enter a movement direction");
    int direction = Convert.ToInt32(Console.ReadLine());

    game.Move(direction);
    Console.WriteLine($"({game.current.X}, {game.current.Y})");
}
Robot robot = new Robot();

//int i = 0;
string response = "";
while (response != "7")
{
    Console.WriteLine("Choose a command\n" +
        "1) turn on\n" +
        "2) turn off\n" +
        "3) move north\n" +
        "4) move south\n" +
        "5) move west\n" +
        "6) move east" +
        "7) stop");
    response = Console.ReadLine();

    switch (response)
    {
        case "1":
            robot.Commands?.Add(new OnCommand());
            break;
        case "2":
            robot.Commands?.Add(new OffCommand());
            break;
        case "3":
            robot.Commands?.Add(new NorthCommand());
            break;
        case "4":
            robot.Commands?.Add(new SouthCommand());
            break;
        case "5":
            robot.Commands?.Add(new WestCommand());
            break;
        case "6":
            robot.Commands?.Add(new EastCommand());
            break;
        case "7":
            break;
        default:
            Console.WriteLine("Invalid command");
            break;
    }
}

robot.Run();

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public List<IRobotCommand> Commands { get; } = new List<IRobotCommand>();

    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    public void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y += 1;
        }
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y -= 1;
        }
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X -= 1;
        }
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X += 1;
        }
    }
}
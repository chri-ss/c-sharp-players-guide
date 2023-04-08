Robot robot = new Robot();

int i = 0;
while (i < robot.Commands.Length)
{
    Console.WriteLine("Choose a command\n" +
        "1) turn on\n" +
        "2) turn off\n" +
        "3) move north\n" +
        "4) move south\n" +
        "5) move west\n" +
        "6) move east");
    string response = Console.ReadLine();

    switch (response)
    {
        case "1":
            robot.Commands[i] = new OnCommand();
            break;
        case "2":
            robot.Commands[i] = new OffCommand();
            break;
        case "3":
            robot.Commands[i] = new NorthCommand();
            break;
        case "4":
            robot.Commands[i] = new SouthCommand();
            break;
        case "5":
            robot.Commands[i] = new WestCommand();
            break;
        case "6":
            robot.Commands[i] = new EastCommand();
            break;
        default:
            Console.WriteLine("Invalid command");
            break;
    }
    i++;
}

robot.Run();

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];

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
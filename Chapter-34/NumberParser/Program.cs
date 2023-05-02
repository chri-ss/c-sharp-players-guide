while (true)
{
    Console.WriteLine("Enter a number");
    string? num = Console.ReadLine();

    if (int.TryParse(num, out int iVal))
    {
        Console.WriteLine($"Your number is {iVal}");
    }
    else if (double.TryParse(num, out double dVal))
    {
        Console.WriteLine($"Your number is {dVal}");
    }
    else if (bool.TryParse(num, out bool bVal))
    {
        Console.WriteLine($"Your boolean is {bVal}");
    }
    else
    {
        Console.WriteLine("Not a number");
    }
}
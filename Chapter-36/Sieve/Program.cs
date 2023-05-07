Sieve sieve = new Sieve(Sieve.IsEven);

Console.WriteLine("Choose");

int response = Convert.ToInt32(Console.ReadLine());

if (response == 1)
{
    sieve = new Sieve(Sieve.IsEven);
}
else if (response == 2)
{
    sieve = new Sieve(Sieve.IsPositive);
}
else if (response == 3)
{
    sieve = new Sieve(Sieve.IsMultipleOfTen);
}

while (true)
{
    Console.WriteLine("Enter a num");
    response = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(sieve.IsGood(response));
}

class Sieve
{
    public delegate bool FilterDelegate(int number);

    public FilterDelegate filterDelegate;

    public Sieve(FilterDelegate filterDel)
    {
        filterDelegate = filterDel;
    }

    public bool IsGood(int number)
    {
        return filterDelegate(number);
    }

    public static bool IsEven(int number)
    {
        if (number % 2 == 0)
        {
            return true;
        }
        return false;
    }

    public static bool IsPositive(int number)
    {
        return number > 0;
    }

    public static bool IsMultipleOfTen(int number)
    {
        if (number % 10 == 0)
        {
            return true;
        }
        return false;
    }
}
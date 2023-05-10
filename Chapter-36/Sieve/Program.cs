Sieve sieve = new Sieve(n => true);

Console.WriteLine("Choose");

int response = Convert.ToInt32(Console.ReadLine());

if (response == 1)
{
    sieve = new Sieve(n => n % 2 == 0);
}
else if (response == 2)
{
    sieve = new Sieve(n => n > 0);
}
else if (response == 3)
{
    sieve = new Sieve(n => n % 10 == 0);
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
}
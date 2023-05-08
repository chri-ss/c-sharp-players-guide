CharberryTree tree = new CharberryTree();

Notifier notifier = new Notifier(tree);
Harvester havester = new Harvester(tree);

while (true)
{
    tree.MaybeGrow();
}

while (true)
{
    tree.MaybeGrow();
}

public class CharberryTree
{
    private Random _random = new Random();

    public bool Ripe { get; set; }

    public event Action<CharberryTree>? Ripened;

    public void MaybeGrow()
    {
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            if (Ripe)
            {
                Ripened(this);
            }
        }
    }
}

public class Notifier
{
    public Notifier(CharberryTree tree)
    {
        tree.Ripened += OnRipened;
    }

    //parameter not used here
    public void OnRipened(CharberryTree tree) => Console.WriteLine("The fruit has ripened.");
}

public class Harvester
{
    public Harvester(CharberryTree tree)
    {
        tree.Ripened += OnHarvest;
    }

    public void OnHarvest(CharberryTree tree)
    {
        tree.Ripe = false;
        Console.WriteLine("Fruit harvested.");
    }
}
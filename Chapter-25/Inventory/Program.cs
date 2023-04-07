Pack pack = new Pack();

while (true)
{
    Console.WriteLine("Choose what to add to your inventory:\n" +
        "1) Arrow\n" +
        "2) Bow\n" +
        "3) Rope\n" +
        "4) Water\n" +
        "5) Food\n" +
        "6) Sword\n");

    string selection = Console.ReadLine();

    switch (selection)
    {
        case "1":
            Arrow arrow = new Arrow();
            pack.Add(arrow);
            break;

        case "2":
            Bow bow = new Bow();
            pack.Add(bow);
            break;

        case "3":
            Rope rope = new Rope();
            pack.Add(rope);
            break;

        case "4":
            Water water = new Water();
            pack.Add(water);
            break;

        case "5":
            Food food = new Food();
            pack.Add(food);
            break;

        case "6":
            Sword sword = new Sword();
            pack.Add(sword);
            break;

        default:
            Console.WriteLine("Invalid option\n");
            break;
    }

    Console.WriteLine(pack.ToString());
}

class Pack
{
    public InventoryItem[] Items = new InventoryItem[4];
    public float MaxWeight = 7f;
    public float MaxVolume = 8f;

    public float Weight { get; private set; } = 0f;
    public float Volume { get; private set; } = 0f;

    public int Count { get { return Items.Length; } }

    public bool Add(InventoryItem item)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i] == null && (Weight + item.Weight) <= MaxWeight && (Volume + item.Volume) <= MaxVolume)
            {
                Items[i] = item;
                Weight += item.Weight;
                Volume += item.Volume;
                return true;
            }
            else if (Items[i] == null && Weight + item.Weight > MaxWeight)
            {
                Console.WriteLine("Exceeds weight limit.");
                break;
            }
            else if (Items[i] == null && Volume + item.Volume > MaxVolume)
            {
                Console.WriteLine("Exceeds volume limit.");
                break;
            }
        }

        if (Items[Items.Length - 1] != null)
        {
            Console.WriteLine("Pack is full.");
        }

        Console.WriteLine("unable to add item.\n");
        return false;
    }

    public override string ToString()
    {
        string items = "";
        foreach (InventoryItem item in Items)
        {
            if (item != null)
            {
                items += item.ToString() + " ";
            }
        }

        return $"A pack containing {items}";
    }
}

class InventoryItem
{
    public float Weight { get; protected set; }
    public float Volume { get; protected set; }
}

class Arrow : InventoryItem
{
    public Arrow()
    {
        Weight = 0.1f;
        Volume = 0.05f;
    }
}

class Bow : InventoryItem
{
    public Bow()
    {
        Weight = 1f;
        Volume = 4f;
    }
}

class Rope : InventoryItem
{
    public Rope()
    {
        Weight = 1f;
        Volume = 1.5f;
    }
}
class Water : InventoryItem
{
    public Water()
    {
        Weight = 2f;
        Volume = 3f;
    }
}

class Food : InventoryItem
{
    public Food()
    {
        Weight = 1f;
        Volume = 0.5f;
    }
}

class Sword : InventoryItem
{
    public Sword()
    {
        Weight = 5f;
        Volume = 3f;
    }
}
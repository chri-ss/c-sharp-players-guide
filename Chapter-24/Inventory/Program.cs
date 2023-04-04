Pack pack = new Pack();

Arrow arrow = new Arrow();

Console.WriteLine(pack.Add(arrow));

Console.WriteLine(pack.Items[0]);

class Pack
{
    public InventoryItem[] Items = new InventoryItem[4];
    public float MaxWeight = 7f;
    public float MaxVolume = 8f;

    public float Weight { get; private set; } = 0f;
    public float Volume { get; private set; } = 0f;

    public bool Add(InventoryItem item)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i] == null && (Weight + item.Weight) < MaxWeight && (Volume + item.Volume) < MaxVolume)
            {
                Items[i] = item;
                Weight += item.Weight;
                Volume += item.Volume;
                return true;
            }
        }
        return false;
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
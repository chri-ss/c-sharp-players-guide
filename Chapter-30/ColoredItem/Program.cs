ColoredItem<Sword> sword = new ColoredItem<Sword>(new Sword(), ConsoleColor.Blue);
ColoredItem<Bow> bow = new ColoredItem<Bow>(new Bow(), ConsoleColor.Red);
ColoredItem<Axe> axe = new ColoredItem<Axe>(new Axe(), ConsoleColor.Green);

sword.Display();
bow.Display();
axe.Display(); 

public class Sword
{

}

public class Bow
{

}

public class Axe
{

}

public class ColoredItem<T>
{
    public T item { get; private set; }

    public ConsoleColor itemColor { get; private set; }

    public ColoredItem(T item, ConsoleColor itemColor)
    {
        this.item = item;
        this.itemColor = itemColor;
    }

    public void Display()
    {
        Console.ForegroundColor = itemColor;
        Console.WriteLine(item?.ToString());
    }
}
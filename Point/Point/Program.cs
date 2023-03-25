Point p1 = new Point(2, 3);

Point p2 = new Point(-4, 0);

Console.WriteLine($"({p1.X}, {p1.Y})");
Console.WriteLine($"({p2.X}, {p2.Y})");

class Point
{
    public int _x;
    public int _y;

    public int X { get; private set; }
    public int Y { get; private set; }
    public (int x, int y) Origin { get; private set; } = (x: 0, y: 0);
    public int DistX() => Abs(0 - X);
    public int DistY() => Abs(0 - Y);

    public Point(int x, int y)
    {
        X = x;
        Y = y;

    }

    public Point()
    {
        X = Origin.x; Y = Origin.y;
    }

    public int Abs(int n)
    {
        if (n < 0)
        {
            n = -n;
        }
        return n;
    }
}
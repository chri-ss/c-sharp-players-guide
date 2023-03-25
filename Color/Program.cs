Color color1 = Color.MakeColor(37, 66, 102);
Color color2 = Color.Yellow;

color1.LogColor();
color2.LogColor();

class Color
{
    int min = 0;
    int max = 255;

    public int MyRed { get; private set; }
    public int MyGreen { get; private set; }
    public int MyBlue { get; private set; }

    private Color(int r, int g, int b)
    {
        MyRed = r;
        MyGreen = g;
        MyBlue = b;
    }

    public static Color MakeColor(int r, int g, int b)
    {
        if(r >= 0 &&  g >= 0 && b >= 0 && r <= 255 && g <= 255 && b <= 255)
        {
            return new Color(r, g, b);
        }
        else
        {
            return null;
        }
    }

    public void LogColor()
    {
        Console.WriteLine($"({MyRed}, {MyGreen}, {MyBlue})");
    }

    public static Color Black { get { return new Color(0, 0, 0); } }
    public static Color White { get { return new Color(255, 255, 255); } }
    public static Color Red { get { return new Color(255, 0, 0); } }
    public static Color Green { get { return new Color(0, 255, 0); } }
    public static Color Blue { get { return new Color(0, 0, 255); } } 
    public static Color Yellow { get { return new Color(255, 255, 0); } }
    public static Color Orange { get { return new Color(255, 165, 0); } }
    public static Color Purple { get { return new Color(160, 32, 240); } }
}
class Color
{
    int min = 0;
    int max = 255;

    public int Red { get; private set; }
    public int Green { get; private set; }
    public int Blue { get; private set; }

    public (int r, int g, int b) rbg;

    public Color(int r, int g, int b)
    {
        Red = r;
        Green = g;
        Blue = b;
    }
}
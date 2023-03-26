for (int i = 0; i < Enum.GetNames(typeof(EColor)).Length; i++)
{
    for (int j = 0; j < Enum.GetNames(typeof(ERank)).Length; j++)
    {
        Card card = new Card((EColor)i, (ERank)j);
        Console.WriteLine($"The {card.Color} {card.Rank}");
    }
}

class Card
{
    public EColor Color { get; private set; }
    public ERank Rank { get; private set; }

    public Card(EColor clr, ERank rnk)
    {
        Color = clr;
        Rank = rnk;
    }

    public bool IsFace()
    {
        if (Rank == ERank.Dollar || Rank == ERank.Percent || Rank == ERank.Caret || Rank == ERank.Ampersand)
        {
            return true;
        }
        return false;
    }
}

enum EColor { Red, Green, Blue, Yellow }

enum ERank { Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Caret, Ampersand }


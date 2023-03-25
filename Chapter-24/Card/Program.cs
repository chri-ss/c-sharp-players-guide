class Card
{
    public EColor Color { get; set; }
    public ERank Rank { get; set; }

    public Card(EColor clr, ERank rnk)
    {
        Color = clr;
        Rank = rnk;
    }
}

enum EColor { Red, Green, Blue, Yellow }

enum ERank { Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Caret, Ampersand }


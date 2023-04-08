Coordinate coord = new Coordinate(3, 4);

Coordinate coord2 = new Coordinate(4, 5);

Coordinate coord3 = new Coordinate(5, 6);

Console.WriteLine(coord.IsAdjacent(coord2));
Console.WriteLine(coord.IsAdjacent(coord3));


public struct Coordinate
{
    public readonly int Row { get; }
    public readonly int Column { get; }

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public bool IsAdjacent(Coordinate coord)
    {
        if (coord.Row == Row - 1 || coord.Row == Row + 1 ||
            coord.Column == Column - 1 || coord.Column == Column + 1)
        {
            return true;
        }
        return false;
    }
}
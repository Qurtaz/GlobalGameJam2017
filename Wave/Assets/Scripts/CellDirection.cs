public enum CellDirection
{
    NE, E, SE, SW, W, NW
}

public static class CellDirectionExtensions
{
    public static CellDirection Opposite(this CellDirection direction)
    {
        return (int)direction < 3 ? (direction + 3) : (direction - 3);
    }

    public static CellDirection Previous(this CellDirection direction)
    {
        return direction == CellDirection.NE ? CellDirection.NW : (direction - 1);
    }

    public static CellDirection Next(this CellDirection direction)
    {
        return direction == CellDirection.NW ? CellDirection.NE : (direction + 1);
    }

    public static CellDirection Previous2(this CellDirection direction)
    {
        direction -= 2;
        return direction >= CellDirection.NE ? direction : (direction + 6);
    }

    public static CellDirection Next2(this CellDirection direction)
    {
        direction += 2;
        return direction <= CellDirection.NW ? direction : (direction - 6);
    }
}
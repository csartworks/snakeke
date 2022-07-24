internal class Snake
{
    internal static readonly char Symbol = 'O';

    public Snake(int x, int y)
    {
        Pos = (x, y);
    }
    public (int x, int y) Pos { get; internal set; }


}
public enum Direction
{
    Up, Down, Left, Right
}

public static class Extensions
{
    public static (int, int) ToMovement(this Direction direction) => direction switch
    {
        Direction.Up => (0, -1),
        Direction.Down => (0, 1),
        Direction.Left => (-1, 0),
        Direction.Right => (1, 0),
        _ => (0, 0)
    };
    public static Direction? ToDirection(this ConsoleKey key) => key switch
    {
        ConsoleKey.RightArrow => Direction.Right,
        ConsoleKey.L => Direction.Right,
        ConsoleKey.LeftArrow => Direction.Left,
        ConsoleKey.H => Direction.Left,
        ConsoleKey.DownArrow => Direction.Down,
        ConsoleKey.J => Direction.Down,
        ConsoleKey.UpArrow => Direction.Up,
        ConsoleKey.K => Direction.Up,
        _ => null
    };
    public static (int, int)? ToTuple(this ConsoleKey key) => key switch
    {
        ConsoleKey.RightArrow => (1, 0),
        ConsoleKey.L => (1, 0),
        ConsoleKey.LeftArrow => (-1, 0),
        ConsoleKey.H => (-1, 0),
        ConsoleKey.DownArrow => (0, 1),
        ConsoleKey.J => (0, 1),
        ConsoleKey.UpArrow => (0, -1),
        ConsoleKey.K => (0, -1),
        _ => null
    };
}

public struct Position
{
    public int x, y;

    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static implicit operator Position((int x, int y) v)
    {
        return new Position(v.x, v.y);
    }
}
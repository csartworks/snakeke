internal class Snake
{
    internal static readonly char Symbol = 'O';

    public Snake(int x, int y)
    {
        Pos = (x, y);
    }
    public Position Pos { get; internal set; }
}
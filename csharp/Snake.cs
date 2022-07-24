internal class Snake
{
    internal static readonly char Symbol = 'O';

    public Snake(int x, int y)
    {
        Pos = (x, y);
    }
    public (int x, int y) Pos { get; internal set; }
}
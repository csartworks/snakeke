internal class Game
{
    private const int _game_width = 20;
    private const int _game_height = 10;
    private const char _horizontalWall = '-';
    private const char _verticalWall = '|';
    private const string _verticalWallLineBreak = "|\n";
    public Game()
    {

    }

    public string LastOutput { get; private set; } = "";

    private void Print(object v)
    {
        Console.WriteLine(v);
        LastOutput = (string)v;
    }
    internal string DrawArena_SingleLine()
    {
        return "|" + new string(' ', _game_width) + "|";
    }

    internal void DrawArena()
    {
        Print(DrawArenaHorizontalBorder());
        for (int i = 0; i < _game_height; i++)
        {
            Print(DrawArena_SingleLine());
        }
        Print(DrawArenaHorizontalBorder());
    }

    public string DrawArenaHorizontalBorder()
    {
        return _verticalWall + new String(_horizontalWall, _game_width) + _verticalWall;
    }
}
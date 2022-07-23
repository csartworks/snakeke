internal class Game
{
    private const int _game_width = 12;
    private const char _horizontalWall = '-';
    private const char _verticalWall = '|';
    public Game()
    {
    }

    public string LastOutput {get; private set;}

    private void Print(object v)
    {
        LastOutput = (string)v;
        Console.WriteLine(v);
    }

    internal void DrawArenaSideBorder()
    {
        throw new NotImplementedException();
    }

    public void DrawArenaUpperBorder()
    {
        Print(_verticalWall + new String(_horizontalWall, _game_width) + _verticalWall);
    }
}
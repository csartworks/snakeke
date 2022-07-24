internal class Game
{
    public const int game_width = 20;
    public const int game_height = 10;
    private const char _horizontalWall = '-';
    private const char _verticalWall = '|';
    private const string _verticalWallLineBreak = "|\n";
    private char[,] _map = new char[game_width, game_height];
    public Game()
    {

    }

    public string LastOutput { get; private set; } = "";
    public (int x, int y) SnakePos => Snake.Pos;
    public Snake Snake { get; private set; }
    public bool IsGameOver { get; private set; }


    internal string DrawArena_SingleLine()
    {
        return "|" + new string(' ', game_width) + "|";
    }

    internal void DrawArena()
    {
        Console.WriteLine(DrawArenaHorizontalBorder());
        for (int i = 0; i < game_height; i++)
        {
            Console.WriteLine(DrawArena_SingleLine());
        }
        Console.WriteLine(DrawArenaHorizontalBorder());
    }

    internal void SpawnSnake()
    {
        SpawnSnake(game_width / 2, game_height / 2);
    }

    public string DrawArenaHorizontalBorder()
    {
        return _verticalWall + new String(_horizontalWall, game_width) + _verticalWall;
    }

    internal char GetCharAt(int x, int y)
    {
        return _map[x, y];
    }

    public const char NULL = '\0';
    internal void ElapseTime()
    {
        EraseAt(SnakePos.x, SnakePos.y);
        Snake.Pos = (Snake.Pos.x, Snake.Pos.y - 1);
        if (SnakePos.x < 0 || SnakePos.y < 0)
        {
            IsGameOver = true;
            return;
        }
        WriteAt(Snake.Symbol, SnakePos.x, SnakePos.y);

    }
    private void EraseAt(int x, int y)
    {
        _map[x, y] = NULL;
        Console.SetCursorPosition(x, y);
        Console.Write(' ');
    }
    private void WriteAt(char v, int x, int y)
    {
        _map[x, y] = v;
        Console.SetCursorPosition(x, y);
        Console.Write(v);
    }

    internal void SpawnSnake(int x, int y)
    {
        Snake = new Snake(x, y);
        _map[x, y] = Snake.Symbol;
        Console.SetCursorPosition(x, y);
        Console.Write(Snake.Symbol);
    }
}
internal class Game
{

    public const char NULL = '\0';
    private char[,] _map = new char[ArenaBuilder.game_width + 1, ArenaBuilder.game_height + 1];
    public string LastOutput { get; private set; } = "";
    private (int x, int y) SnakePos => Snake.Pos;
    public Snake Snake { get; private set; } = default!;
    public bool IsGameOver { get; private set; }
    internal char GetCharAt(int x, int y)
    {
        return _map[x, y];
    }
    private void EraseAt(int x, int y)
    {
        _map[x, y] = NULL;
        Console.SetCursorPosition(x, y);
        Console.Write(' ');
    }
    public void WriteAt(char v, int x, int y)
    {
        _map[x, y] = v;
        Console.SetCursorPosition(x, y);
        Console.Write(v);
    }

    internal void SpawnSnake()
    {
        SpawnSnake(ArenaBuilder.game_width / 2, ArenaBuilder.game_height / 2);
    }
    internal void SpawnSnake(int x, int y)
    {
        Snake = new Snake(x, y);
        SetSnakeDirection(Direction.Up);
        _map[x, y] = Snake.Symbol;
        Console.SetCursorPosition(x, y);
        Console.Write(Snake.Symbol);
    }
    internal void ElapseTime()
    {
        EraseAt(SnakePos.x, SnakePos.y);
        Snake.Pos = (Snake.Pos.x + SnakeMovement.x, Snake.Pos.y + SnakeMovement.y);
        if (SnakePos.x < 0 || SnakePos.x > ArenaBuilder.game_width || SnakePos.y < 0 || SnakePos.y > ArenaBuilder.game_height)
        {
            IsGameOver = true;
            return;
        }
        WriteAt(Snake.Symbol, SnakePos.x, SnakePos.y);
    }

    private (int x, int y) SnakeMovement { get; set; }
    internal void SetSnakeDirection(Direction direction)
    {
        SnakeMovement = direction.ToMovement();
    }
    internal void SetSnakeDirection((int, int) direction)
    {
    }
}
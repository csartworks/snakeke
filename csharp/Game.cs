internal class Game
{

    public const char FOOD = '*';
    public const char NULL = '\0';
    private char[,] _map = new char[ArenaBuilder.game_width + 1, ArenaBuilder.game_height + 1];
    public string LastOutput { get; private set; } = "";
    private (int x, int y) SnakePos => Snake.Pos;
    public Snake Snake { get; private set; } = default!;
    public bool IsGameOver { get; private set; }
    private (int x, int y) SnakeMovement { get; set; }
    public int SnakeLength { get; internal set; } = 1;
    private Random rnd = new();
    internal char GetAt(int x, int y)
    {
        return _map[x, y];
    }
    public char GetAt((int x, int y) v) => GetAt(v.x, v.y);
    private void EraseAt(int x, int y)
    {
        _map[x, y] = NULL;
        Console.SetCursorPosition(x, y);
        Console.Write(' ');
    }
    public void EraseAt((int x, int y) v) => EraseAt(v.x, v.y);



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
        TailPoses.Enqueue(SnakePos);
        SetSnakeDirection(Direction.Up);
        _map[x, y] = Snake.Symbol;
        Console.SetCursorPosition(x, y);
        Console.Write(Snake.Symbol);
    }
    private Queue<Position> TailPoses = new();
    internal void ElapseTime()
    {
        Snake.Pos = (Snake.Pos.x + SnakeMovement.x, Snake.Pos.y + SnakeMovement.y);
        if (SnakePos.x < 0 || SnakePos.x > ArenaBuilder.game_width || SnakePos.y < 0 || SnakePos.y > ArenaBuilder.game_height)
        {
            IsGameOver = true;
            return;
        }
        char c = GetAt(Snake.Pos);
        if (c == FOOD)
        {
            SnakeLength++;
            Program.score += 1000;
            Program.CurrentGameSpeed = 1000 - 100 * SnakeLength;
            Program.GameTimer = new(Program.CurrentGameSpeed);
            Program.GameTimer.Start();
            SpawnFood();
        }
        else if (c != Snake.Symbol)
        {
            Position tail = TailPoses.Dequeue();
            EraseAt(tail.x, tail.y);
        }
        else if (c == Snake.Symbol)
        {
            IsGameOver = true;
            return;
        }
        WriteAt(Snake.Symbol, SnakePos.x, SnakePos.y);
        TailPoses.Enqueue(SnakePos);
    }

    internal void SetSnakeDirection(Direction direction) => SetSnakeDirection(direction.ToMovement());
    internal void SetSnakeDirection((int x, int y) direction, bool force = false)
    {
        if (SnakeMovement.x + direction.x == 0 && SnakeMovement.y + direction.y == 0)
        {
            return;
        }
        SnakeMovement = direction;
    }

    internal void SpawnFood(int x, int y)
    {
        WriteAt(FOOD, x, y);
    }
    internal void SpawnFood()
    {
        SpawnFood(rnd.Next(1, ArenaBuilder.game_width), rnd.Next(1, ArenaBuilder.game_height));
    }
}
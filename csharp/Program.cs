using System.Timers;
using Timer = System.Timers.Timer;
public class Program
{
    private static int currentTick;
    private const int foodRate = 20;//the higher it is, the slower it is
    public static int score;
    public static Timer GameTimer;
    public const int GameSpeed = 1000;
    public static int CurrentGameSpeed = GameSpeed;
    public static void Main(string[] args)
    {
        Console.Clear();
        Console.CursorVisible = false;
        ArenaBuilder.DrawArena();
        Game game = new Game();
        game.SpawnSnake();
        game.SpawnFood();
        // game.WriteAt('x', ArenaBuilder.game_width, ArenaBuilder.game_height);

        GameTimer = new(GameSpeed);
        GameTimer.Elapsed += OnTick;
        GameTimer.Enabled = true;
        GameTimer.Start();

        Timer inputTimer = new(100);
        GameTimer.Elapsed += OnInputTick;
        GameTimer.Enabled = true;
        GameTimer.Start();


        while (!game.IsGameOver)
        {

        }
        StatusLine.Write($"Score : {score}  Speed : {CurrentGameSpeed} \nYour Snake Died.");
        Console.CursorVisible = true;
        Environment.Exit(0);

        void OnTick(object? source, ElapsedEventArgs e)
        {
            currentTick++;
            if (currentTick % foodRate == 0) game.SpawnFood();
            if (game.IsGameOver) return;
            game.ElapseTime();
            score += (int)MathF.Pow(game.SnakeLength, game.SnakeLength) / 2;
            StatusLine.Write($"Score : {score}  Speed : {CurrentGameSpeed}");

        }

        void OnInputTick(object? source, ElapsedEventArgs e)
        {
            ConsoleKeyInfo info = Console.ReadKey(true);
            (int, int)? dir = info.Key.ToTuple();
            if (dir is not (int, int) dir2) return;
            game.SetSnakeDirection(dir2);
        }
    }
}
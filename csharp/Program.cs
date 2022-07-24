using System.Timers;
using Timer = System.Timers.Timer;
public class Program
{
    private static int currentTime;
    public static void Main(string[] args)
    {
        Console.Clear();
        Console.CursorVisible = false;
        ArenaBuilder.DrawArena();
        Game game = new Game();
        game.SpawnSnake();
        game.SpawnFood();
        // game.WriteAt('x', ArenaBuilder.game_width, ArenaBuilder.game_height);

        Timer timer = new(800);
        timer.Elapsed += OnTick;
        timer.Enabled = true;
        timer.Start();
        while (!game.IsGameOver)
        {

        }
        Console.WriteLine("Your snake died.");
        Console.CursorVisible = true;
        Environment.Exit(0);

        void OnTick(object? source, ElapsedEventArgs e)
        {
            currentTime++;
            if (currentTime % 10 == 0) game.SpawnFood();
            if (game.IsGameOver) return;
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo info = Console.ReadKey(true);
                (int, int)? dir = info.Key.ToTuple();
                if (dir is (int, int) dir2)
                {
                    game.SetSnakeDirection(dir2);
                }
            }
            game.ElapseTime();
        }
    }
}
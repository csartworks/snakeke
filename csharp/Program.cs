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

        Timer gameTime = new(800);
        gameTime.Elapsed += OnTick;
        gameTime.Enabled = true;
        gameTime.Start();

        Timer inputTimer = new(5);
        gameTime.Elapsed += OnInputTick;
        gameTime.Enabled = true;
        gameTime.Start();

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
            game.ElapseTime();
        }

        void OnInputTick(object? source, ElapsedEventArgs e)
        {
            ConsoleKeyInfo info = Console.ReadKey(true);
            (int, int)? dir = info.Key.ToTuple();
            if (dir is (int, int) dir2)
            {
                game.SetSnakeDirection(dir2);
            }
            // if (Console.KeyAvailable)
            // {
            //     ConsoleKeyInfo info = Console.ReadKey(true);
            //     (int, int)? dir = info.Key.ToTuple();
            //     if (dir is (int, int) dir2)
            //     {
            //         game.SetSnakeDirection(dir2);
            //     }
            // }
        }
    }
}
using System.Timers;
using Timer = System.Timers.Timer;
public class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        ArenaBuilder.DrawArena();
        Game game = new Game();
        game.SpawnSnake();
        game.SpawnFood(3, 3);
        // game.WriteAt('x', ArenaBuilder.game_width, ArenaBuilder.game_height);

        Timer timer = new(500);
        timer.Elapsed += OnTick;
        timer.Enabled = true;
        timer.Start();
        while(!game.IsGameOver)
        {

        }
        Console.WriteLine("Your snake died.");

        void OnTick(object? source, ElapsedEventArgs e)
        {
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
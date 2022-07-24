// Console.WriteLine("Hello");
// Thread.Sleep(1000);
// Console.WriteLine("World");

Console.Clear();
Game game = new Game();
game.DrawArena();
game.SpawnSnake();

for (int i = 0; i < 10; i++)
{
    Thread.Sleep(1000);
    game.ElapseTime();
}
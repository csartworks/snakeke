// Console.WriteLine("Hello");
// Thread.Sleep(1000);
// Console.WriteLine("World");

Console.Clear();
Game game = new Game();
game.DrawArena();
game.SpawnSnake();

while (!game.IsGameOver)
{
    Thread.Sleep(1000);
    game.ElapseTime();
}
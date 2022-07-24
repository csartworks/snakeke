public class ArenaBuilder
{
    public const int game_width = 20;
    public const int game_height = 10;
    private const char _horizontalWall = '-';
    private const char _verticalWall = '|';
    private const char _corner = '+';
    public static string DrawArenaHorizontalBorder()
    {
        return _corner + new String(_horizontalWall, game_width) + _corner;
    }
    public static string DrawArena_SingleLine()
    {
        return _verticalWall + new string(' ', game_width) + _verticalWall;
    }
    public static void DrawArena()
    {
        Console.WriteLine(DrawArenaHorizontalBorder());
        for (int i = 0; i < game_height; i++)
        {
            Console.WriteLine(DrawArena_SingleLine());
        }
        Console.WriteLine(DrawArenaHorizontalBorder());
    }
}
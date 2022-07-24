public class ArenaBuilder
{
    public const int game_width = 20;
    public const int game_height = 10;
    private const char _horizontalWall = '-';
    private const char _verticalWall = '|';
    private const string _verticalWallLineBreak = "|\n";
    public static string DrawArenaHorizontalBorder()
    {
        return _verticalWall + new String(_horizontalWall, game_width) + _verticalWall;
    }
    public static string DrawArena_SingleLine()
    {
        return "|" + new string(' ', game_width) + "|";
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
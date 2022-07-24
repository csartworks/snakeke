internal class StatusLine
{
    internal static void Write(string v)
    {
        Console.SetCursorPosition(0, ArenaBuilder.game_height + 2);
        Console.Write(v);
    }
}
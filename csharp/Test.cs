using Xunit;
public class Test
{
    [Fact]
    public void ArenaDrawTest_UpperBorder()
    {
        Game game = new Game();
        string upperBorder = game.DrawArenaHorizontalBorder();
        Assert.Equal("|--------------------|", upperBorder);
    }
    [Fact]
    public void ArenaDrawTest_DrawSingleLine()
    {
        Game game = new Game();
        string singleLine = game.DrawArena_SingleLine();
        Assert.Equal("|                    |", singleLine);
    }
    [Fact]
    public void ArenaDrawTest()
    {
        Game game = new Game();
        game.DrawArena();
    }
}
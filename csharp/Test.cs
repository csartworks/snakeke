using Xunit;
public class Test
{
    [Fact]
    public void ArenaDrawTest_UpperBorder()
    {
        Game game = new Game();
        game.DrawArenaUpperBorder();
        Assert.Equal("|------------|", game.LastOutput);
    }
    [Fact]
    public void ArenaDrawTest_SideBorder()
    {
        Game game = new Game();
        game.DrawArenaSideBorder();
        Assert.Equal("|------------|", game.LastOutput);
    }
}
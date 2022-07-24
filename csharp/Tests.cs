using Xunit;
public class DrawArenaTest
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

public class SnakeTest
{
    [Fact]
    public void SnakeTest_SpawnSnakeAtTheMiddle()
    {
        Game game = new();
        game.SpawnSnake();
        Assert.Equal(Snake.Symbol, game.GetCharAt(10, 5));
        Assert.Equal(game.SnakePos, (10, 5));
    }
    [Fact]
    public void MapTest_GetCharAt()
    {
        Game game = new();
        Assert.Equal('\0', game.GetCharAt(0,0));
    }
    [Fact]
    public void SnakeTest_SnakeMovesEverySecond()
    {
        Game game = new();
        game.SpawnSnake();
        game.ElapseTime();
        Assert.Equal('\0', game.GetCharAt(10, 5));
        Assert.Equal(Snake.Symbol, game.GetCharAt(10, 4));
    }
    [Fact]
    public void SnakeTest_SnakeDeath()
    {
        Game game = new();
        game.SpawnSnake(0, 0);
        game.ElapseTime();
        Assert.Equal(true, game.IsGameOver);
    }
}
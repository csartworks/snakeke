using Xunit;
public class DrawArenaTest
{
    [Fact]
    public void ArenaDrawTest_UpperBorder()
    {
        string upperBorder = ArenaBuilder.DrawArenaHorizontalBorder();
        Assert.Equal("|--------------------|", upperBorder);
    }
    [Fact]
    public void ArenaDrawTest_DrawSingleLine()
    {
        Game game = new Game();
        string singleLine = ArenaBuilder.DrawArena_SingleLine();
        Assert.Equal("|                    |", singleLine);
    }
    [Fact]
    public void ArenaDrawTest()
    {
        Game game = new Game();
        ArenaBuilder.DrawArena();
    }
    [Fact]
    public void MapTest_GetCharAt()
    {
        Game game = new();
        Assert.Equal('\0', game.GetCharAt(0, 0));
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
        Assert.Equal(game.Snake.Pos, (10, 5));
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
    [Fact]
    public void SnakeTest_TurnRight()
    {
        Game game = new();
        game.SpawnSnake();
        game.SetSnakeDirection(Direction.Right);
        game.ElapseTime();
        Assert.Equal(Snake.Symbol, game.GetCharAt(11, 5));
    }
    [Fact]
    public void SnakeTest_TurnLeft()
    {
        Game game = new();
        game.SpawnSnake();
        game.SetSnakeDirection(Direction.Left);
        game.ElapseTime();
        Assert.Equal(Snake.Symbol, game.GetCharAt(9, 5));
    }
}
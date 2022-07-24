using Xunit;
public class DrawArenaTest
{
    [Fact]
    public void ArenaDrawTest_HorizontalBorder()
    {
        string upperBorder = ArenaBuilder.DrawArenaHorizontalBorder();
        Assert.Equal("+--------------------+", upperBorder);
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
        Assert.Equal('\0', game.GetAt(0, 0));
    }
}

public class SnakeTest
{
    [Fact]
    public void SnakeTest_SpawnSnakeAtTheMiddle()
    {
        Game game = new();
        game.SpawnSnake();
        Assert.Equal(Snake.Symbol, game.GetAt(10, 5));
        Assert.Equal(game.Snake.Pos, (10, 5));
    }
    [Fact]
    public void SnakeTest_SnakeMovesEverySecond()
    {
        Game game = new();
        game.SpawnSnake();
        game.ElapseTime();
        Assert.Equal('\0', game.GetAt(10, 5));
        Assert.Equal(Snake.Symbol, game.GetAt(10, 4));
    }
    [Fact]
    public void SnakeTest_SnakeDeath()
    {
        Game game = new();
        game.SpawnSnake(0, 0);
        game.ElapseTime();
        Assert.True(game.IsGameOver);
    }
    [Fact]
    public void SnakeTest_SnakeDiesIfCatchesItSelf()
    {
        Game game = new();
        game.SpawnSnake(0, 0);
        game.SpawnFood(1, 0);
        game.SpawnFood(2, 0);
        game.SpawnFood(3, 0);
        game.SpawnFood(4, 0);
        game.SetSnakeDirection(Direction.Right);
        game.ElapseTime();
        game.ElapseTime();
        game.ElapseTime();
        game.ElapseTime();
        game.SetSnakeDirection(Direction.Down);
        game.ElapseTime();
        game.SetSnakeDirection(Direction.Left);
        game.ElapseTime();
        game.SetSnakeDirection(Direction.Right);
        game.ElapseTime();
        Assert.True(game.IsGameOver);
    }
    [Fact]
    public void SnakeTest_TurnRight()
    {
        Game game = new();
        game.SpawnSnake();
        game.SetSnakeDirection(Direction.Right);
        game.ElapseTime();
        Assert.Equal(Snake.Symbol, game.GetAt(11, 5));
    }
    [Fact]
    public void SnakeTest_TurnLeft()
    {
        Game game = new();
        game.SpawnSnake();
        game.SetSnakeDirection(Direction.Left);
        game.ElapseTime();
        Assert.Equal(Snake.Symbol, game.GetAt(9, 5));
    }
    [Fact]
    public void SnakeTest_LengthenSnake()
    {
        Game game = new();
        game.SpawnSnake(0, 0);
        game.SetSnakeDirection(Direction.Right);
        Assert.Equal(Snake.Symbol, game.GetAt(0, 0));
        game.SpawnFood(1, 0);
        game.ElapseTime();
        Assert.Equal(2, game.SnakeLength);
        Assert.Equal(Snake.Symbol, game.GetAt(0, 0));
        Assert.Equal(Snake.Symbol, game.GetAt(1, 0));
        game.ElapseTime();
        Assert.Equal(Game.NULL, game.GetAt(0, 0));
        Assert.Equal(Snake.Symbol, game.GetAt(1, 0));
        Assert.Equal(Snake.Symbol, game.GetAt(2, 0));
    }
}

public class FoodTest
{
    [Fact]
    public void FoodTest_TestFoodSpawn()
    {
        Game game = new();
        game.SpawnSnake();
        game.SpawnFood(10, 3);
        Assert.Equal(1, game.SnakeLength);
        game.ElapseTime();
        Assert.Equal(1, game.SnakeLength);
        game.ElapseTime();
        Assert.Equal(2, game.SnakeLength);
    }
}
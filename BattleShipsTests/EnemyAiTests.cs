using System.Drawing;
using BShips;

namespace BattleShipsTests;

public class BattleShipsUnitTest
{
    [Fact]
    public void TestCreatesValidRandomGuess()
    {
        //Arrange
        var prevEnemyGuesses = new List<Point>(){Capacity = 100};
        var sut = new EnemyAi();

        //Act
        var guess = sut.RandomGuess(prevEnemyGuesses);
        
        //Assert
        Assert.True(guess.X is >= 0 and <= 9 && guess.Y is >=0 and <=9);
    }
    
    [Fact]
    public void TestNoDuplicateGuesses()
    {
        //Arrange
        var containsDuplicateValue = false;
        var prevEnemyGuesses = new List<Point>(){Capacity = 100};
        var sut = new EnemyAi();
            
        //Act
        for (var i = 0; i < 100; i++)
        {
            sut.RandomGuess(prevEnemyGuesses);
        }

        if (prevEnemyGuesses.Count != prevEnemyGuesses.Distinct().Count())
        {
            containsDuplicateValue = true;
        }
        //Assert
        Assert.False(containsDuplicateValue);
    }

    [Fact]
    public void TestThrowExceptionAfterMaxGuesses()
    {
        //Arrange
        var prevEnemyGuesses = new List<Point>(){Capacity = 0};
        var sut = new EnemyAi();
        
        //Act and Assert
        Assert.Throws<OperationCanceledException>(() => sut.RandomGuess(prevEnemyGuesses));
    }
}
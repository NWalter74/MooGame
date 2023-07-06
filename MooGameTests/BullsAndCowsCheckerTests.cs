namespace MooGameTests;

[TestClass]
public class BullsAndCowsCheckerTests
{
    [TestMethod]
    public void CheckBC_ShouldReturnExpectedResult()
    {
        // Arrange
        var bullsAndCowsChecker = new BullsAndCowsChecker();
        string goal = "1234";
        string guess = "1243";
        string expected = "BB,CC";

        // Act
        string result = bullsAndCowsChecker.CheckBC(goal, guess);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void IsCorrectGuess_ShouldReturnTrue_WhenBullsAndCowsAreCorrect()
    {
        // Arrange
        var bullsAndCowsChecker = new BullsAndCowsChecker();
        string bbcc = "BBBB,";

        // Act
        bool result = bullsAndCowsChecker.IsCorrectGuess(bbcc);

        // Assert
        Assert.IsTrue(result);
    }
}
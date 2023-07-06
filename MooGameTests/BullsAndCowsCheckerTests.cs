using Moq;

namespace MooGameTests;

[TestClass]
public class BullsAndCowsCheckerTests
{
    //[TestMethod]
    //public void CheckBC_ShouldReturnExpectedResult()
    //{
    //    // Arrange
    //    var bullsAndCowsChecker = new BullsAndCowsChecker();
    //    string goal = "1234";
    //    string guess = "1243";
    //    string expected = "BB,CC";

    //    // Act
    //    string result = bullsAndCowsChecker.CheckBC(goal, guess);

    //    // Assert
    //    Assert.AreEqual(expected, result);
    //}

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

    [TestMethod]
    public void CheckBC_ShouldReturnExpectedResult()
    {
        // Arrange
        var bullsAndCowsChecker = new BullsAndCowsChecker();
        string goal = "1234";
        string guess = "1243";
        string expected = "BBCC";

        // Act
        string result = bullsAndCowsChecker.CheckBC(goal, guess);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void ConsoleUserInterface_GetUserName_ShouldReturnExpectedValue()
    {
        // Arrange
        var userInterfaceMock = new Mock<IUserInterface>();
        userInterfaceMock.Setup(ui => ui.GetUserName()).Returns("John");

        var inventoryController = new InventoryController(userInterfaceMock.Object, null, null);

        // Act
        string userName = inventoryController.GetUserName();

        // Assert
        Assert.AreEqual("John", userName);
    }

    //[TestMethod]
    //public void CheckBC_ShouldReturnCorrectBullsAndCowsCount()
    //{
    //    // Arrange
    //    string goal = "1234";
    //    string guess = "1423";
    //    BullsAndCowsChecker checker = new BullsAndCowsChecker();

    //    // Act
    //    string result = checker.CheckBC(goal, guess);

    //    // Assert
    //    Assert.AreEqual("B,CCC", result);
    //}

    //[TestMethod]
    //public void IsCorrectGuess_ShouldReturnTrueForCorrectGuess()
    //{
    //    // Arrange
    //    string bbcc = "BBBB,";
    //    BullsAndCowsChecker checker = new BullsAndCowsChecker();

    //    // Act
    //    bool result = checker.IsCorrectGuess(bbcc);

    //    // Assert
    //    Assert.IsTrue(result);
    //}

    //[TestMethod]
    //public void IsCorrectGuess_ShouldReturnFalseForIncorrectGuess()
    //{
    //    // Arrange
    //    string bbcc = "BBCC";
    //    BullsAndCowsChecker checker = new BullsAndCowsChecker();

    //    // Act
    //    bool result = checker.IsCorrectGuess(bbcc);

    //    // Assert
    //    Assert.IsFalse(result);
    //}
}
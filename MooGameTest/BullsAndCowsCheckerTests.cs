using MooGame;
using Moq;

namespace MooGameTest
{
    [TestClass]
    public class BullsAndCowsCheckerTests
    {
        [TestMethod]
        public void CheckBC_ShouldReturnExpectedResult()
        {
            // Arrange
            var userInterfaceMock = new Mock<IUserInterface>();
            var gameMock = new Mock<IGame>();

            var checker = new BullsAndCowsChecker();

            string goal = "1234";
            string guess = "1243";
            string expected = "BB,CC";

            gameMock.Setup(g => g.CheckBC(goal, guess)).Returns(expected);

            // Act
            string result = checker.CheckBC(goal, guess);

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
}
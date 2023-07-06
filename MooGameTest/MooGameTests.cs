using MooGame;
using Moq;

namespace MooGameTest
{
    [TestClass]
    public class MooGameTests
    {
        [TestMethod]
        public void CheckBC_ShouldReturnExpectedResult()
        {
            // Arrange
            var bullsAndCowsCheckerMock = new Mock<BullsAndCowsChecker>();
            var game = new MooGame(new GoalGenerator(), bullsAndCowsCheckerMock.Object);
            string goal = "1234";
            string guess = "1243";
            string expected = "BBCC";
            bullsAndCowsCheckerMock.Setup(b => b.CheckBC(goal, guess)).Returns(expected);

            // Act
            string result = game.CheckBC(goal, guess);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsCorrectGuess_ShouldReturnTrueForCorrectGuess()
        {
            // Arrange
            var bullsAndCowsCheckerMock = new Mock<BullsAndCowsChecker>();
            var game = new MooGame(new GoalGenerator(), bullsAndCowsCheckerMock.Object);
            string bbcc = "BBBB,";

            // Act
            bool result = game.IsCorrectGuess(bbcc);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
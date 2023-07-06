namespace MooGameTests;

[TestClass]
public class GoalGeneratorTests
{
    [TestMethod]
    public void GenerateGoal_ReturnsFourDigitNumber()
    {
        // Arrange
        GoalGenerator goalGenerator = new GoalGenerator();

        // Act
        string goal = goalGenerator.GenerateGoal();

        // Assert
        Assert.AreEqual(4, goal.Length);
        foreach (char c in goal)
        {
            Assert.IsTrue(char.IsDigit(c));
        }
    }
}

namespace MooGameTests;

[TestClass]
public class PlayerDataTests
{
    [TestMethod]
    public void GetAverage_ReturnsCorrectAverage()
    {
        // Arrange
        PlayerData playerData = new PlayerData("John", 10);

        // Act
        double average = playerData.GetAverage();

        // Assert
        Assert.AreEqual(10.0, average);
    }
}

using MooGame;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MooGameTest
{
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
}

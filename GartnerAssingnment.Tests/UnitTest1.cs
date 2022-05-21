using GartnerAssignment;
using NUnit.Framework;

namespace GartnerAssingnment.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_yaml()
        {
            //Arrange
            string fileName = "capterra.yaml";

            //Act
            var isComplete = FileParser.ParseFile(fileName);

            //Assert
            var result = (bool)isComplete;
        }

        [Test]
        public void Test_json()
        {
            //Arrange
            string fileName = "softwareadvice.json";

            //Act
            var isComplete = FileParser.ParseFile(fileName);

            //Assert
            var result = (bool)isComplete;
            Assert.AreEqual(true, result);
        }
    }
}
using NUnit.Framework;

namespace PCBuilderTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("")]
        public void UserAddedToTheDatabase()
        {
            Assert.Pass();
        }
    }
}
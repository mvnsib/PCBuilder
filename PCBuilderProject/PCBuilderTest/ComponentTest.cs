using NUnit.Framework;

namespace PCBuilderTest
{
    public class ComponentTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("")]
        public void CompnentTest()
        {
            Assert.Pass();
        }
    }
}
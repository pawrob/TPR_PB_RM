using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP_Unit_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int x = 5;
            Assert.IsTrue(x == 5, "TestMethod1 has failed");
        }
    }
}

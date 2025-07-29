using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoCalculator;
namespace CalculatorTest.MSTest
{
    [TestClass]
    public sealed class Test1
    {
        Calculator calculator;

        [TestInitialize]
        public void SetUp()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void TestAdd()
        {
            int result = calculator.Add(2, 3);
            Assert.AreEqual(5, result);

        }

        [TestMethod]
        public void TestSub()
        {
            int result = calculator.Sub(5, 2);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestMul()
        {
            int result = calculator.Mul(3, 2);
            Assert.AreEqual(6, result);

        }

        [TestMethod]
        public void TestDiv()
        {
            decimal result = calculator.Div(10, 2);
            Assert.AreEqual(5, result);

        }


        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDiv2()
        {
            calculator.Div(5, 0);

        }

    }
}

//add our project as well as unit test package 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoCalculator;
namespace MathLibraryTest.MsTest
{
    [TestClass]
    public sealed class Test1
    {
        private Calculator? calculator; //ref of a class

        [TestInitialize]
        public void SetUp()
        {
            calculator = new Calculator(); //allocationg memory
        }


        [TestMethod]
        public void AddReturnMul()
        {
            int result = calculator!.Mul(3, 2);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void AddReturnDiv()
        {
            decimal result = calculator!.Div(10,2);
            Assert.AreEqual(5, result);
        }
    }
}

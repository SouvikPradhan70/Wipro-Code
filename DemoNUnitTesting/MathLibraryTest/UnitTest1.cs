//importing NUnit.Framework and our application
using DemoNUnitTesting;
using MyApp;
using NUnit.Framework;
namespace MathLibraryTest
{
    public class CalculatorTests
    {
        private Calculator calculator;
        [SetUp]
        public void Setup()
        {
            calculator = new Calculator(); //allocating memory using new keyword

        }

        [Test]
        public void Add_ShouldReturnCorrectSum()
        {
            //Assert.Pass(); for passing the flow of execution
            int result=calculator.Add(2, 3);
            //Assert.AreEqual(5, result);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Sub_ShouldReturnCorrectDifference()
        {
            //Assert.Pass();
            int result = calculator.Sub(5, 3);
            Assert.That(result, Is.EqualTo(2));
        }
    }
}
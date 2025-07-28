using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoEmailVerify;
namespace EmailValidation.MSTest
{
    [TestClass]
    public sealed class Test1
    {
        private EmailVerification emailVerification;

        [TestInitialize]
        public void TestInitialize()
        {
            emailVerification = new EmailVerification();
        }

        [TestMethod]
        public void IsEmailValid_ShouldReturnFalseForInvalidEmail()
        {
            string input = "Invalid_email.com";
            bool result= emailVerification.EmailVerify(input);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void IsEmailValid_ShouldReturnTrueForInvalidEmail()
        {
            string input="souvikpradhan70@gmail.com";
            bool result=emailVerification.EmailVerify(input);
            Assert.IsTrue(result);
        }
    }


}


using DemoEmailVerify;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
        private readonly EmailVerification emailVerify=new EmailVerification();


        [Fact]
        public void TeIsEmailValid_ShouldReturnFalseForInvalidEmailst1()
        {
            string input = "Hiihello_by.com";
            bool result = emailVerify.EmailVerify(input);
            Assert.False(result);
        }

        [Fact]
        public void TeIsEmailValid_ShouldReturnTrueForInvalidEmailst1()
        {
            string input= "souvikpradhan70@gmail.com";
            bool result = emailVerify.EmailVerify(input);
            Assert.True(result);

        }
    }
}
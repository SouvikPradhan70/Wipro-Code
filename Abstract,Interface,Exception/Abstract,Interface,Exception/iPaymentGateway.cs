using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Interface_Exception
{
    internal interface iPaymentGateway
    {
        //here we wil define the method that will be implemented in the derived class
        void Pay(decimal amount);
        void Refund(decimal amount);
    }
    internal class PaymentGateway : iPaymentGateway
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Payment of {amount} processed through the payment gateway.");
        }
        public void Refund(decimal amount)
        {
            Console.WriteLine($"Refund of {amount} processed through the payment gateway.");
        }
    }
}

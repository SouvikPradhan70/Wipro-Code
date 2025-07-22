using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Interface_Exception
{
    abstract class Payment
    {
        //defining class members like properties and methods specially for abstrct method
        public string PaymentId { get; set; }

        public abstract void MakePayment(decimal amount);

        public void GenerateReceipt()
        {
            Console.WriteLine($"Receipt generated for payment ID: {PaymentId}");
        }
    }
}

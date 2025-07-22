using Abstract_Interface_Exception;
using System;       
namespace AbstractInterfaceException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting started with the Abstact class and Interface");
            //makesound class which will predefine  method which can be derived in child class
            //step 1: Create an abstract class
            //step 2: Create an interface
            //step 3:impliment the abstact class and interface in the derived class(why? because abstarct class cant be instantiated)
            //step 4:create an instance of the derived class and call the methods

            Console.WriteLine("Here is an abstarct class demo:");
            Payment payment=new creditCardPayment(); 
            payment.MakePayment(100.50m);//coming from derived class
            payment.GenerateReceipt();//coming from abstarct class

            Console.WriteLine("Here is an interface demo:");
            iPaymentGateway paymentGateway = new PaymentGateway();
            paymentGateway.Pay(200.75m); //calling the method from interface
            paymentGateway.Refund(50.25m); //calling the method from interface

        }
    }


    class creditCardPayment : Payment
    {
        //implement the abstract method MakePayment
        public override void MakePayment(decimal amount)
        {
            //implementation of the abstract method
            Console.WriteLine($"Payment of {amount} made using Credit Card. Payment ID: {PaymentId}");
            PaymentId=Guid.NewGuid().ToString();
        }
    }

}

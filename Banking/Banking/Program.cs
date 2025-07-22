//helloworld 
//here we want to handle a n exception for insufficient balance in a bank account
// you have to follow folllowing step for above implementation 
//Step 1: Create a class that inherits from Exception
//Step 2: Create a constructor that takes a message parameter and passes it to the base class constructor
//Step 3: Optionally, you can add additional properties or methods if needed
//Step 4: Use the custom exception in your code where you want to validate balance
//Create a class with bank Account and a method to withdraw money
//Your class should have Balance property with getter and  private setter
using System;
namespace Banking
{
    class BankAcc
    {
        public decimal Balance { get; private set; }
        public BankAcc(decimal MyBalance)
        {
            Balance= MyBalance;
        }
        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new MyException("Insufficient balance for withdrawal.");
            }

            else
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawal successful! New balance: {Balance}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Banking Application!");
            try
            {
                BankAcc bankAcc = new BankAcc(1000);
                Console.WriteLine($"Initial Balance: {bankAcc.Balance}");

                Console.WriteLine("Enter amount to withdraw:");
                decimal amt = Convert.ToDecimal(Console.ReadLine());

                bankAcc.Withdraw(amt);
            }
            catch (MyException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }




        }
        
    }

    

}

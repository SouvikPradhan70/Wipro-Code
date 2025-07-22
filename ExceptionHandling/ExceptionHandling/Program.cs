using System;
namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exception Handling Example");
            //Exception exp=new Exception("This is a custom exception message"); //exception is my base class for all type of exceptions
            //try
            //{
            //    //take two number from user to check division by zero exception
            //    Console.Write("Enter the first number: ");
            //    int num1 = Convert.ToInt32(Console.ReadLine());
            //    Console.Write("Enter the second number: ");
            //    int num2 = Convert.ToInt32(Console.ReadLine());
            //    decimal result = (decimal)num1 / num2; //this will throw an exception if num2 is zero
            //    Console.WriteLine("The result of division is: " + result);


            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("An exception occurred: " + ex.Message);

            //    throw;
            //}
            //finally
            //{
            //    Console.WriteLine("This block always executes,Now cleaning up the memory!!");
            //}

            //step 1:we creating an instance for OrderProcessing class
            OrderProcessing orderprocessing = new OrderProcessing();

            try
            {
                Console.Write("Enter your age: ");
                int age = Convert.ToInt32(Console.ReadLine());
                validateAge(age); //this will throw an exception if age is less than 18

            }
            catch (AgeValidationException ex)
            {

                Console.WriteLine("An exception occurred: " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Thank you for using our service!");
            }
            static void validateAge(int age)
            {
                if (age < 18)
                {
                    throw new AgeValidationException("Age must be 18 or older to place an order.");
                }
                else
                {
                    Console.WriteLine("Age is valid for placing an order.");
                }

            }


        }
    }
}
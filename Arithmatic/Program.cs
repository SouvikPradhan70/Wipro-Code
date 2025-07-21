using System;

namespace Arithmatic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number:");
            int num1 =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number:");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int sum = num1 + num2;
            int diff = num1 - num2;
            int pro = num1 * num2;
            double div = (double)num1 / num2;

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The difference is: {diff}");
            Console.WriteLine($"The product is: {pro}");
            Console.WriteLine($"The quotient is: {div}");
            
        }
    }
}
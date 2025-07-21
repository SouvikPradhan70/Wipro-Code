using System;

namespace ClassNObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Following are the standard steps for implemting Classes and Objects in C#");
            Console.WriteLine("1. Define a class with properties and methods.");
            Console.WriteLine("2. Create an instance of the class (an object)."); // Instantiation
            Console.WriteLine("3. Access the properties and methods of the object using the dot (.) operator.");
            Console.WriteLine("4. Use the object to perform operations or retrieve data.");
            //We can also static and private members in a class.

            Console.WriteLine("Create a object of Bank ");
            bank b = new bank("souvik", 100000);
            Console.WriteLine(b.AccHlderName);
            Console.WriteLine(b.Balance);
            
        }
    }
}
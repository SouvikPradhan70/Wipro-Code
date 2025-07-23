using System;
namespace Delegates
{
    //step 1: Define a delegate type
    public delegate void GreetUser(string Name);
    class Program
    {

        // Declare a delegate that takes an int and returns void
        public delegate void NumberProcessor(int number);
        static void Main(string[] args)
        {
            //steps for implementing a delegate
            //step 1:Define a delegate type ex syntax: delegate returnType DelegateName(parameterType parameterName);
            //step 2: Create methods matching delegate signature
            //step 3: Create an instance of the delegate and assign a method inside main()

            Greetings newGreetings = new Greetings();
            GreetUser greetuser; //step 3: declare a deligate variable 

            Console.WriteLine("Initially we are using class object to call method sayHello()");
            newGreetings.sayHello("John");

            Console.WriteLine("Now we will use a delegate to call the same method sayHello()");
            greetuser = newGreetings.sayHello;
            greetuser("Raj");

            Console.WriteLine("Now we will use a delegate to call the method sayGoodbye()");
            greetuser = newGreetings.sayGoodbye;
            greetuser("Souvik");
        }
    }
    //step 2: Create a class with methods matching the delegate signature
    public class Greetings
    {
        public void sayHello(string name)
        {
            Console.WriteLine($"Hello {name}");
        }
        public void sayGoodbye(string name)
        {
            Console.WriteLine($"Goodbye {name}");
        }
    }
}
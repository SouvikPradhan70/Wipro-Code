using System;

namespace MyApp
{
    internal class Program
    //non blocking execution
    //Parallel Task
    //Efficient resource management
    //Improved performance
        //why we should use Task insted of thread or threadpool??
        //task simplifies code using async and await keywords
        //it automatically capture exceptions
        //better scalability in async environment
        //it is easier to comibe  chain or cancel task
    {
        static async Task Main(string[] args) //async method make a method asynchronous 
        {
            Console.WriteLine("Async and await method..");
            Console.WriteLine("Fetchh student data...!!!");
            //call async method 
            string result=await FetchStudentDataAsync(); // await tells the compiler to pause the method execution until awaited task complete 
            Console.WriteLine(result);
            Console.WriteLine("Data fetched successfully.");
        }


        static async Task<string> FetchStudentDataAsync()
        {
            await Task.Delay(2000); //simulating delay.. here task represents async operation
            return "Student data fetched sucessfully.";
        }
    }
}

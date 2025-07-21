using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> browserHistory = new Stack<string>();
            browserHistory.Push("google.com");
            browserHistory.Push("facebook.com");
            browserHistory.Push("youtube.com");

            Queue<string> jobs = new Queue<string>();
            jobs.Enqueue("download");
            jobs.Enqueue("print");
            jobs.Enqueue("delete");
            //pop
            Console.WriteLine("Going back browsing: " + browserHistory.Pop());

            //dequeue
            Console.WriteLine("Processing work:" + jobs.Dequeue());

            //remaining browsingHistory
            Console.WriteLine("Remaining browsing history-:");
            foreach(var b in browserHistory)
            {
                Console.WriteLine(b);
            }

            //remaining jobs
            Console.WriteLine("Remaining Jobs-:");
            foreach(var j in jobs)
            {
                Console.WriteLine(j);
            }

        }
    }
}

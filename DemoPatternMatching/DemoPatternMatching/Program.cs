using System;
using System.Security.Cryptography.X509Certificates;

namespace MyApp
{


    internal class Program
    {
        static void Main(string[] args)
        {

            //here the objective is to use pattern natching with switch statement
            //ex if user enters a sentence like i am an SME who is Microsoft Certified and been training candidate since 2010
            //our code should match words like 
            //Python, Java, C#, .NET-technology


            Console.WriteLine("Here is the ppattern matchinng App using swich case:");
            Console.WriteLine("Type exit to quit the app");

            while (true)
            {
                Console.Write("Enter a sentence: ");
                string input = Console.ReadLine();
                if (input?.ToLower() == "exit")
                {
                    Console.WriteLine("Exiting the application...");
                    break;
                }

                string[] words = input.Split(' ');
                bool found = false;

                foreach(string word in words)
                {
                    switch (word.ToLower())
                    {
                        case "python":
                        case "java":
                        case "c#":
                        case ".net":
                            Console.WriteLine($"Found a match: {word}");
                            found = true;
                            break;

                        case "microsoft":
                        case "amazon":
                        case "google":
                            Console.WriteLine($"Found a tech company: {word}");
                            found = true;
                            break;

                        case "sme":
                        case "trainee":
                        case "trainer":
                            Console.WriteLine($"Found a role: {word}");
                            found = true;
                            break;

                    }
                }
                
            }

        }
       
    }
}
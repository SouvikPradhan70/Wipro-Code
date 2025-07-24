
using System;

namespace MyApp
{
    class StudentNames
    {
        private string[] names = new string[10];
        // Indexer to allow array-like access to the names
        public string this[int index]
        {
            get { return names[index]; }
            set { names[index] = value; }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            StudentNames studentnames = new StudentNames();
            studentnames[0] = "John";
            studentnames[1] = "Jane";
            studentnames[2] = "Doe";
            Console.WriteLine($"Student 0 {studentnames[0]}");
            Console.WriteLine($"Student 0 {studentnames[1]}");
            Console.WriteLine($"Student 0 {studentnames[2]}");

            Console.WriteLine("Indexer are used to perform array like indexing on object in c#");
            //Arr[0]="Hello"; what if we want to perform object[index]=value;

        }
    }
}
using System;

namespace dataTypes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int x = 10;
            int y = x;
            y = 20;
            Console.WriteLine($"x={x} & y={y}");



            Person p1 = new Person();
            p1.Name = "Raj";
            Person p2 = new Person();
            p2 = p1;
            p2.Name = "Hunny";
            Console.WriteLine($"p1={p1.Name} & p2={p2.Name}");
        }
        public class Person
        {
            public string Name;
        }
        
        
    }
}

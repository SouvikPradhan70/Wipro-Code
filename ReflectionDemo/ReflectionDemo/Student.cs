using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    public class Student
    {
        public int ID;
        public string Name;
        public int Age;

        public Student(int id, string name, int age)
        {
            ID = id;
            Name = name;
            Age = age;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Agge: {Age}");
        }
        public int getId(){ return id; }
        public string getName() { return name; }
    }
    public class Emp
    {

    }
}

using ReflectionDemo;
using System;
using System.Reflection; //for showing metadata at runtime 

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //this feature allow us to inspect with metadata. tyypes ,properties, methods and assemblies at runtime
            Type studentType = typeof(Student); //Here student type is of type student class
            Console.WriteLine("Class Name: " + studentType.Name);
            Type EmpType = typeof(Emp);
            Console.WriteLine("Class Name: " + EmpType.Name);

            //FIELDS
            Console.WriteLine("Here are the list of fields in following type");
            foreach(var field in studentType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine($" -{field.Name}: {field.FieldType} ");
            }

            Console.WriteLine("Reading Properties");
            foreach (var prop in studentType.GetProperties())
            {
                Console.WriteLine($" -{prop.Name}: {prop.PropertyType}");
            }

            //constructor from my class
            Console.WriteLine("Reading Constructors");
            foreach (ConstructorInfo ctor in studentType.GetConstructor())
            {
                foreach(ParameterInfo pram in  ctor.GetParameters())
                {
                    Console.WriteLine($" -{pram.Name}: {pram.ParameterType}");
                }
                Console.WriteLine();
            }

            //methods from my class
            Console.WriteLine("Reading Methods");
            foreach(MethodInfo method in studentType.GetMethod(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly))
            {
                Console.WriteLine($" -{method.Name}: {method.ReturnType}");
            }


        }
    }
}

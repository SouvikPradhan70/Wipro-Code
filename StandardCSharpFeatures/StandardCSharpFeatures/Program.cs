
using StandardCSharpFeatures;
using System;
using System.Runtime.CompilerServices;

namespace MyApp
{
    public static class StringExtension
    {
        public static bool IsPalindrome(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            var reversed = new string(str.Reverse().ToArray());
            return string.Equals(str, reversed, StringComparison.OrdinalIgnoreCase);

        }

        public static bool IsCpitalized(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            return char.IsUpper(str[0]);

        }


        public static int CountVowels(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;
            return str.Count(c => "aeiouAEIOU".Contains(c));
        }




        //tuple and destructionn in c# 7.0

        public static (int num, int Product) CalculateSumAndProduct(this int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return (0, 0);
            int sum = numbers.Sum();
            int product = numbers.Aggregate(1, (acc, x) => acc * x); //calculating product
            return (sum, product); //returning sum and product
        }

    }

    //print pattern in c#
    public class PatternMatchingDemo
    {
        void PrintTyes(object obj)
        {
            if (obj is int i)
            {
                Console.WriteLine($"Integer: {i}");
            }
            else if (obj is double d)
            {
                Console.WriteLine($"Double {d}");
            }
            else if (obj is string s)
            {
                Console.WriteLine($"String {s}");

            }
            else
            {
                Console.WriteLine("No type is matching");
            }
        }
    }
    public class LocalFunction
    {
        void CalculationAndDisplay(int x, int y)
        {
            int Add(int a, int b) => a + b; //localfunction
            Console.WriteLine($"Addition result: {Add(x, y)}");

        }
    }

    public class RefandOUT_variables
    {
        public static ref int FindFirstEven(ref int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    return ref numbers[i];

                }
            }
            throw new Exception("no even number found");
        }

    }

    public class  StudentExpression_Bodied_Member{
        private string _name;
        public StudentExpression_Bodied_Member(string name) => _name= name; //expression boddied method

        public string Display => $"Sudent name: {_name}";
        

    }

    internal class Program: Employee
    {
        static void Main(string[] args)
        {

            //Discard(_)
            //A discard is a write only variable
            //tuple deconstruction
            //out parameters
            //patterns matching
            //swich expression
            //async result

            //if (int.TryParse("456", out _))
            //{
            //    Console.WriteLine("Parsing suceed"); // here i am intensionally ignoring this value
            //}


            //(string FName,string LName,int age) GetPerson() =>( "Riya","Kumari",24);
            //var(_,_,personAge)=GetPerson();
            //Console.WriteLine();


            var (_, age, role) = GetEmployee();
            DisplayRole(role);

            Console.WriteLine($"Experience: {CalculateExperience(2014)} years ");
            Console.WriteLine("manager".ToTitleCase());
            if (int.TryParse("29",out int empAge))
            {
                Console.WriteLine($"Age verified{empAge}");


            }

            Employee emp = new Employee { Name = "Rahul", Role = "manager" };
            Console.WriteLine(emp.Info);

            int[] salaries = { 30000, 45000, 60000 };
            ref int targetSalary = ref Find(ref salaries, 45000);
            targetSalary=70000;
            Console.WriteLine($"Update salary: {salaries[1]} ");
        }
        //Method implementation 
        static (string, int, string) GetEmployee() => ("Tarun", 29, "Developer");
        static void DisplayRole(string Role)
        {
            if (Role is "Manager")
            {
                Console.WriteLine("Welcome Manager..!");
            }
            else if (Role is "Developer")
            {
                Console.WriteLine("Welcome Developer");

            }
            else
            {
                Console.WriteLine("Welcome staff");
            }

        }

        static int CalculateExperience(int joinYear)
        {
            int Current() => DateTime.Now.Year;
            return Current()-joinYear;
        }


        public static ref int Find(ref int[] arr, int value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == value)
                {
                    return ref arr[i];

                }
                
            }
            throw new Exception("Value Not found!");


        }

    }
}



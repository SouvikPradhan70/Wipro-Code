using System;
namespace CollectionOfObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Demo based on collection of objecs using list<T> and Dictionary<TKey,TValue>");
            Console.WriteLine(" How List<t> and Dictionary<TKey,Tvalue> are implemented ");
            Console.WriteLine(" What are the best use case of implementing above collections ");

            List<Employee> employees = new List<Employee>
            {
                new Employee(100,"Hunny","IT"),
                new Employee(101,"Souvik","HR"),
                new Employee(102,"Remo","Pion")
            };

            foreach(var emp in employees)
            {
                Console.WriteLine($"ID: {emp.ID}, Name: {emp.Name}, Department: {emp.Department}");
            }

            Dictionary<int, Employee> dictEmployee = new Dictionary<int, Employee>();
            foreach(var emp2 in employees)
            {
                dictEmployee[emp2.ID] = emp2;
            }


            Console.WriteLine(" \n Enter an Employee ID to search:");
            int searchId = Convert.ToInt32(Console.ReadLine());

            if (dictEmployee.TryGetValue(searchId, out Employee foundEmp))// here we are using TryGetValue method to search for an employee by ID
                                                                                //out parameter foundEmp will hold the employee object if found
                                                                                //searchId is the key we are looking for in the dictionary
            {
                Console.WriteLine($"Employee Found : {foundEmp.Name} and Emp Dept: {foundEmp.Department}");

            }
            else
            {
                Console.WriteLine($"Employee with ID {searchId} not found.");
            }

        }
    }

    public class Employee 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public Employee(int id,string name,string dept)
        {
            ID = id;
            Name = name;
            Department = dept;

        }




    }


}

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;



namespace FileHandlingStream
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public Employee(int id, string name, string department)
        {
            Id = id;
            Name = name;
            Department = department;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //in file handling we have file stream which a implemented via stream
            //serialization which is implemented via System.Text.Json
            //Deserialization which is implemented via System.Text.Json
            //why: it is used whenever we want to read or write data to a file in a structured way

            //step 1: create a list of employees
            List<Employee> employees = new List<Employee>
            {
                new Employee(1, "Alice", "HR"),
                new Employee(2, "Bob", "IT"),
                new Employee(3, "Charlie", "Finance")
            };

            string filepath = "employees.json";

            try
            {
                using(FileStream fs=new FileStream(filepath, FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize(fs,employees);

                }

                Console.WriteLine("Data written to file successfully.");

                //reading json filefrom the file
                FileStream read= new FileStream(filepath, FileMode.Open);

                List<Employee> deserializedEmployees = JsonSerializer.Deserialize<List<Employee>>(read);


                //displaying the deserialized data
                if (deserializedEmployees != null)
                {
                    foreach (var employee in deserializedEmployees)
                    {
                        Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name}, Department: {employee.Department}");
                    }
                }
                else
                {
                    Console.WriteLine("No employees found.");
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            

        }
    }
}
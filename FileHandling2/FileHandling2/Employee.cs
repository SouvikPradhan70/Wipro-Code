using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace FileHandling2
{
    public class Employee
    {

        //step 1:create a class to represent an employee with properties like ID, Name, and Salary
        public int ID { get; set; }
        public String Name { get; set; }
        public double Salary { get; set; }

        //step 2: create a constructor to initialize the properties
        public Employee(int id, string name, double salary)
        {
            ID = id;
            Name = name;
            Salary = salary;


        }
        //defining a class variable of type collection to hold emloyees
        public static List<Employee> Employees = new List<Employee>();
        string filePath = "employees.txt";

        //step 3: override the ToString() method to return a string representation of the employee
        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Salary: {Salary}";

        }
        //step 4: create a method to save employee details to a file
        public void SaveToFile(string filePath)
        {
            using (var writer = new StreamWriter(filePath, true)) // 'true' to append to the file
            {
                writer.WriteLine(this.ToString());
            }
        }

        //step 5: create an add employee method to add an employee.
        public static void AddEmployee(List<Employee> employees, string filepath)
        {
            Console.WriteLine("Enter Employee ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Employee Salary:");
            double salary = Convert.ToDouble(Console.ReadLine());
            // Create a new employee object
            Employee employee = new Employee(id, name, salary);
            employees.Add(employee);
            // Save the employee details to the file
            employee.SaveToFile(filepath);
            Console.WriteLine("Employee added successfully.");
        }
        //step 6: create a method to view all employees
        public void ViewAllEmployees(List<Employee> employees)
        {
            Console.WriteLine("List of Employees:");
            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }

        }
        //step 7: create a method to search for an employee by ID
        public void SearchByID()
        {
            Console.WriteLine("Enter Employee ID to search:");
            int id = Convert.ToInt32(Console.ReadLine());
            var employee = Employees.FirstOrDefault(e => e.ID == id);
            if (employee != null)
            {
                Console.WriteLine($"Employee found: {employee}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        //step 8: create a method to Update employee salary
        public void UpdateSalary()
        {
            Console.WriteLine("Enter Employee ID to update salary:");
            int id = Convert.ToInt32(Console.ReadLine());
            var employee = Employees.FirstOrDefault(e => e.ID == id);
            if (employee != null)
            {
                Console.WriteLine("Enter new salary:");
                double newSalary = Convert.ToDouble(Console.ReadLine());
                employee.Salary = newSalary;
                Console.WriteLine($"Salary updated for {employee.Name}. New Salary: {employee.Salary}");
                // Save the updated employee details to the file
                SaveToFile(filePath);
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        //step 9: create a method to delete an employee by ID
        public void DeleteEmployee()
        {
            Console.WriteLine("Enter Employee ID to delete:");
            int id = Convert.ToInt32(Console.ReadLine());
            var employee = Employees.FirstOrDefault(e => e.ID == id);
            if (employee != null)
            {
                Employees.Remove(employee);
                Console.WriteLine($"Employee with ID {id} deleted successfully.");
                // Optionally, you can also remove the employee from the file
                // This would require rewriting the file without the deleted employee
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
        //step 10: create a method to save employees details to a file
        public void SaveEmpEMPtoDile()
        {
            var json = System.Text.Json.JsonSerializer.Serialize(Employees);
            File.WriteAllText(filePath, json);
            Console.WriteLine("Employee details saved to file successfully.");
        }
        //step 11: create a method to load employees from a file
        public void LoadEmployeesFromFile()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                Employees = System.Text.Json.JsonSerializer.Deserialize<List<Employee>>(json);
                Console.WriteLine("Employees loaded from file successfully.");
            }
            else
            {
                Console.WriteLine("File does not exist. No employees loaded.");
            }
        }


        //step 12: create a method to disply the menu and handle user choices
        public static void DisplayMenu()
        {
            Employee emp = new Employee(0, "", 0);
            int choice;
            do
            {
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Employee Salary");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Save Employees to File");
                Console.WriteLine("7. Load Employees from File");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddEmployee(Employees, emp.filePath);
                        break;
                    case 2:
                        emp.ViewAllEmployees(Employees);
                        break;
                    case 3:
                        emp.SearchByID();
                        break;
                    case 4:
                        emp.UpdateSalary();
                        break;
                    case 5:
                        emp.DeleteEmployee();
                        break;
                    case 6:
                        emp.SaveEmpEMPtoDile();
                        break;
                    case 7:
                        emp.LoadEmployeesFromFile();
                        break;
                    case 8:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 8);
        }


    }
}

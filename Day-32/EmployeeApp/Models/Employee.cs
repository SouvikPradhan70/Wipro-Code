namespace EmployeeApp.Models
{
    public class Employee
    {
        public int Id { get; set; } //primary key
        public string? Name { get; set; }
        public string? Department { get; set; }
        public float Salary{ get; set; }
    }
}
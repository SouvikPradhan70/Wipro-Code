using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace StudentReportSystemUsingC_8Feature
{
    public interface IReport
    {
        void GenerateReport(List<Student> students);

        void printtitle();


    }
    public class Student
    {
        public int ID { get; }//readonly member
        public string Name { get; set; }//non-nullable
        public string? Email { get; set; }//nullable
        public int Marks { get; set; }//non-nullable

        public Student(int id, string name, int marks)
        {
            ID = id;
            Name = name;
            Marks = marks;
        }
    }

    public class ReportGenerate : IReport
    {
        public async IAsyncEnumerable<Student> LoadStudentAsync() //here async is used for asynchronous communication and IAsyncEnumerable is used for enumrating type of collection
        {
            //IEnumerable<Student> is an interface in c# that represent a sequence of Student objects that can be enumaerated(iterae over)
            var students = new List<Student> {
                new Student(1,"Rajat",85),
                new Student(2,"Nidhi",86),
                new Student(3,"Sreekant",89),
                new Student(4,"Raghab",90)
            };
            foreach (var student in students)
            {
                await Task.Delay(300); //simulating delay fetch
                yield return student; //yield return is used to implement iterator method to return element one at a time

            }
        }

        public async void GenerateReport(List<Student> students)
        {
            printtitle();
            foreach (var student in students)
            {
                string grade = student.Marks switch
                {
                    >= 90 => "A",
                    >= 80 => "B",
                    >= 70 => "C",
                    _ => "D"
                };
                Console.WriteLine($" Name: {student.Name,-10} | Marks: {student.Marks,-3} | Grade: {grade}"); //-10 and -3 are not of char we want to display
            }

        }
    }
    public static class ReportUtils
    {
        public static List<Student> GoTopPerformance(List<Student> students)
        {
            var sorted = students.OrderByDescending(s => s.Marks).Take(3).ToList();
            return sorted[..3];//using range  to slice top 3 values

        }
    }

    //create a class for exporting report
    public static class ExportHelper 
    {
        public static void ExporReport(List<Student> students)
        {
            using var writer = new StreamWriter("report.txt");
            writer.WriteLine("Student Report");
            foreach (var student in students)
            {
                writer.WriteLine($"ID: {student.ID}, Name: {student.Name}, Marks: {student.Marks}");
            }


        }
    }








}

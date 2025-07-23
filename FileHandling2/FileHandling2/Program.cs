using FileHandling2;
using System;
using System.IO;
namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Welcome to the file handling operation demo!!");
            ////step 1:create a file if not exists it will be created automatically
            ////step 2:write to the file(it remove previous content and add new content)
            ////step 3:Read from the file
            ////step 4:Append to the file(it will not remove previous content)
            ////step 5:Delete the file

            //string filePath = "demoFile.txt";
            //// Step 1: Create a file if it does not exist
            //using (var fileStream = System.IO.File.Create(filePath))
            //{
            //    Console.WriteLine("File created successfully.");//checking if file is created and opened successfully

            //}
            ////step 2: Write to the file
            //File.WriteAllText(filePath, "Hello this is a demo file");

            ////step 3: read from the file 
            //string content = File.ReadAllText(filePath);
            //Console.WriteLine("After reading the file:");
            //Console.WriteLine(content);

            ////step 4: Append to the file
            //File.AppendAllText(filePath, "\nThis is a appended text in demo");
            //Console.WriteLine("After appending to the file:");
            //content = File.ReadAllText(filePath);
            //Console.WriteLine(content);
            ////for time stamp
            //Console.WriteLine(DateTime.Now);

            ////step 5: Delete the file
            //if (File.Exists(filePath))
            //{
            //    File.Delete(filePath);
            //    Console.WriteLine("File deleted suceessfully.");

            //}
            //else
            //{
            //    Console.WriteLine("File does not exist, so cannot be deleted.");
            //}


            Employee.DisplayMenu();
        }
    }
}

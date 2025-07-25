using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardCSharpFeatures
{
    public class Employee
    {
        //Help an HR department build a lightweight employee info system using c# 7.o feature only
        //Following are some user prospective from a HR prospective
        //store employee info( name ,age ,role)
        //filter employee based on role(using pattern matching)
        //extract and display just sepcific values(using tuple & deconstructor);
        //calculate experience using local function
        //extend string data(Extension Method)
        //use out variables to validate age
        //ignore unwanted data using discard
        //use concise methods(Expression-Bodied member)
        public string Name { get; set; }
        public string Role { get; set; }

        public string Info => $"{Name} is {Role}"; //Expression-Bodied member
        //public string GetEmployee()

    }

    public static class EmpstringExtension  //extension method
    {
        public static string ToTitleCase(this string str) =>
            char.ToUpper(str[0]) + str.Substring(1).ToLower();

    }
}

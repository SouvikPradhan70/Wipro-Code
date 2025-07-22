using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class AgeValidationException : Exception
    {
        public AgeValidationException(string message) : base(message)
        {
            Console.WriteLine("Due to user define/ " + message);

        }

    }
}

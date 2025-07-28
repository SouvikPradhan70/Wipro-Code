using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DemoEmailVerify
{
    public class EmailVerification
    {
        public bool EmailVerify(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            //^ - Start of the string
            //[^@\s]+ : One or more char that are not @ or whitespace(\s)
            //$ : End of he string
            //Mobile no: @"^[6-9]\d{9}$"
            //Pin Code : @"^\d{6}$"


            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}

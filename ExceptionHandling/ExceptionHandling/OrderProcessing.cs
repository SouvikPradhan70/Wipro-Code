using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExceptionHandling
{
    internal class OrderProcessing
    {
        //An online Shopping application processes orders placed by customers.
        //During check out process, multiple operations payemnt, inventory check, order confirmation etc. are performed.
        //They may face following exceptions:
        //INvalid User input Exception
        // Payment Failure Exception
        // Inventory Check Exception/out od stock Exception
        //Null refernce Exception
        //File not found uding logging or invoice generation
        //As developer, you need to handle these exceptions gracefully to ensure a smooth user experience.
        //user Story based on above sceanrio :
        //User tries to place an order for a product. the system must :
        //Validate the Order amount and ensure it is a valid number.
        //Check if the product is in stock.
        //Process the payment and handle any payment failures.
        //Genrate invoices and save to file system.
        //retuern a success message or an error message to the user.

        //step 1:we are creating a inventory data  via collection Dictionary<string,int>
        private Dictionary<string, int> dictonary = new Dictionary<string, int>
        {
            {"Smartphone",1000 },
            {"Laptop",500 },
            {"Tablet",0 }, //out of stock
            {"Smartwatch",200 }
        };

        //step 2:we are creating a method to validate order amount
        


    }
}

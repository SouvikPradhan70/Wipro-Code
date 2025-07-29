using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCalculator
{
    public class Calculator
    {
        public int Add(int a, int b) => a + b;
        public int Sub(int a, int b) => a - b;
        public int Mul(int a, int b) => a * b;
        public decimal Div(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Can't divide with zero!!!");
            }
            return (decimal)a / b;
        }
    }
}

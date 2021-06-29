using System;

namespace Calculator
{
    public class Calc
    {
        public int Sum(int a, int b)
        {
            return checked(a + b);
        }
    }
}



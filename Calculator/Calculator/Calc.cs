using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Calculator.Test_NUnit")]

namespace Calculator
{
    public class Calc
    {
        public int Sum(int a, int b)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                return 12;

            return checked(a + b);
        }

        internal bool TryToTestMe(bool einBool)
        {
            return !einBool;
        }
    }
}



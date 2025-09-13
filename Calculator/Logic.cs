using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class Calc
    {
        public static double Add(double x, double y) { return x + y; }
        public static double Substract(double x, double y) { return x - y; }
        public static double Multiply(double x, double y) { return x * y; }
        public static double Divide(double x, double y) { return x / y; }
        public static double Mod(double x, double y) { return x % y; }
        public static double OneX(double x) { return 1 / x; }

        public static double PowSquared(double x) { return Math.Pow(x, 2); }
        public static double Sqrt(double x) { return Math.Sqrt(x); }

    }
}

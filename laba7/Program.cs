using System;

namespace laba7
{
    class Program
    {
        static void Main()
        {
            RationalFraction a = new RationalFraction(2, 3);
            RationalFraction y = new RationalFraction(2, 3);
            double b=a;
            string c = a;
            a = (RationalFraction)c;
            Console.WriteLine("{0} {1} {2}", c, b, a);
            Console.WriteLine("{0} {1} {2}", a + y, a - y, a * y);
            Console.WriteLine("{0} {1} {2}", a == y, a != y, a > y);
        }
    }
}

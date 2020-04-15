using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinomial
{
    class Program
    {
        static void Main(string[] args)
        {
            Polinomial a = new Polinomial( new double[] { 1,2,3 });
            Console.WriteLine(a);
            Polinomial b = new Polinomial(new double[] { 1,2,3 });
            Console.WriteLine("      " + b);
            a = a * b;
            Console.WriteLine(a);
            a[2] = 3;
            Console.WriteLine(a[2]);
            //b = a;

            if (a == b)
                Console.WriteLine("Equal");
            if (a != b)
                Console.WriteLine("Not equal");
        }
    }
}

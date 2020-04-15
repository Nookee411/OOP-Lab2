using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floating_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 1.25;
            Floating b = new Floating(a);
            Console.WriteLine(b);
            double c = b.ToDouble();
            Console.WriteLine(b.ExponentBinary);
            Console.WriteLine(b.ExponentInt());
            Console.WriteLine(c);
        }
    }
}

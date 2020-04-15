using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction a = new Fraction(2, 3);
            Fraction b = new Fraction(4, 6);
            
            Console.WriteLine(a==b);
        }
    }
}

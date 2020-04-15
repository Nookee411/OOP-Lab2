using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexademical_Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = HexInt.DecToHex(15);
            Console.WriteLine(a);
            string b = "D";
            if (HexInt.IsHex(b))
                Console.WriteLine("That's great");
            else
                Console.WriteLine("That's awful");

            string s = HexInt.And(a, b);
            s = HexInt.Or(a, b);
            Console.WriteLine($"{s}");
        }
    }
}

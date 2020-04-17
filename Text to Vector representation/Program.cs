using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Text_to_Vector_representation
{
    class Program
    {
        static void Main(string[] args)
        {
            Text tom1 = new Text("../../voyna-i-mir-tom-1.txt");
            Text tom2 = new Text("../../voyna-i-mir-tom-2.txt");
            Console.WriteLine(Text.Cos(tom1, tom2));
        }

        
    }
}

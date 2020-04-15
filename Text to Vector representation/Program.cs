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
            StreamReader input1 = new StreamReader("../../voyna-i-mir-tom-1.txt");
            StreamReader input2 = new StreamReader("../../voyna-i-mir-tom-2.txt");
            Text tom1 = new Text();
            while (!input1.EndOfStream)
                tom1.Add(input1.ReadLine());
            input1.Close();
            Text tom2 = new Text();
            while (!input2.EndOfStream)
                tom2.Add(input2.ReadLine());
            //if(tom1.Count!=0&&tom2.Count!=0)
                Console.WriteLine(Text.Cos(tom1, tom2));
            input2.Close();
        }

        
    }
}

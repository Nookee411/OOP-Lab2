using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floating_Numbers
{
    class Floating
    {
        private string data;
        private Byte[] bytes;

        /// <summary>
        /// Converts machine code representation into Double.
        /// </summary>
        /// <returns>Double</returns>
        public double ToDouble()
        {
            return BitConverter.ToDouble(bytes, 0);
        }
        /// <summary>
        /// Sets data with binary representation of floating point value
        /// </summary>
        ///<param name="num">Number to convert in IEEE standart.</param>
        public Floating(Double num)
        {
            StringBuilder sb = new StringBuilder();
            this.bytes = BitConverter.GetBytes(num);
            foreach (byte b in bytes)
                for (int i = 0; i < 8; i++) //each bit con
                {
                    sb.Insert(0, ((b >> i) & 1) == 1 ? "1" : "0");
                }
            this.data = sb.ToString(); //sign exponent mantissa
        }

        public char Sign => data[0];

        public string ExponentBinary => data.Substring(1, 15);

        public int ExponentInt() => Convert.ToInt32(data.Substring(1,15).Trim(), 2);


        /// <summary>
        /// Outputs binary string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return data.Substring(0, 1) + " " + data.Substring(1, 15) + " " + data.Substring(9);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Hexademical_Integer
{
    static class HexInt
    {
        //Constructor

        //Methods
        public static string DecToHex(int a)
        {
            return a.ToString("X");
        }

        public static string Add(string a, string b)
        {
            string res;
            if (HexInt.IsHex(a) && HexInt.IsHex(b))
            {
                int temp = int.Parse(a, NumberStyles.HexNumber)+ int.Parse(b,NumberStyles.HexNumber);
                res = temp.ToString("X");
            }
            else
                throw new Exception("Wrong Hex provided.");
            return res;
        }
        public static string Subsruct(string a, string b)
        {
            string res;
            if (HexInt.IsHex(a) && HexInt.IsHex(b))
            {
                int temp = int.Parse(a, NumberStyles.HexNumber) - int.Parse(b, NumberStyles.HexNumber);
                res = temp.ToString("X");
            }
            else
                throw new Exception("Wrong Hex provided.");
            return res;
        }
        public static bool IsHex(string s)
        {
            try
            {
                int.Parse(s, NumberStyles.HexNumber);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string And(string a,string b)
        {
            a = String.Join(String.Empty, a.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
            b = String.Join(String.Empty, b.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
            return new string(a.Zip(b, (x, y) => (x == '1'&& y=='1') ? '1' : '0').ToArray());
        }

        public static string Or(string a, string b)
        {
            a = String.Join(String.Empty, a.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
            b = String.Join(String.Empty, b.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
            return new string(a.Zip(b, (x, y) => (x=='1'||y=='1') ? '1' : '0').ToArray());
        }

    }
}

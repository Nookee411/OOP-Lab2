using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Text_to_Vector_representation
{
    public class Vector
    {
        private List<double> Values { get; }

        public Vector(List<double> values)
        {
            Values = values;
        }

        public Vector(List<double> values, double length)
        {
            Values = values.Select((x) => x / length).ToList();
        }
        public double Length => Math.Sqrt(Values.Select((x) => x * x).Sum());

        public static double operator *(Vector left, Vector right)
            => left.Values.Zip(right.Values, (x, y) => x * y).Sum();

        public static double Cos(Vector left, Vector right)
            => (left.Length > 0 && right.Length > 0) ? (left * right) / left.Length / right.Length : 0;
    }
    public class Text
    {
        private SortedDictionary<string, int> Dict;
        private HashSet<string> Set;
        private double Length;

        public Text()
        {
            Length = 0;
            Dict = new SortedDictionary<string, int>();
            Set = new HashSet<string>();
        }
        public Text(string text)
        {
            string[] textArr = Regex.Replace(
                new string(text.Where(x => char.IsWhiteSpace(x) || char.IsLetter(x)).Select(char.ToLower)
                    .ToArray()), @"\s+", " ").Split();
            Length = textArr.Length;
            Dict = new SortedDictionary<string, int>();
            Set = new HashSet<string>();
            foreach (string word in textArr)
            {
                if (Dict.ContainsKey(word))
                    Dict[word]++;
                else
                    Dict[word] = 1;
                Set.Add(word);
            }

        }
        public void Add(string text)
        {
            string[] textArr = Regex.Replace(
               new string(text.Where(x => char.IsWhiteSpace(x) || char.IsLetter(x)).Select(char.ToLower)
                   .ToArray()), @"\s+", " ").Split();
            Length += textArr.Length;
            foreach (string word in textArr)
            {
                if (Dict.ContainsKey(word))
                    Dict[word]++;
                else
                    Dict[word] = 1;
                Set.Add(word);
            }
        }

        public static double Cos(Text first, Text second)
        {
            var temp1 = new List<double>();
            var temp2 = new List<double>();
            foreach (var word in first.Set.Intersect(second.Set).ToHashSet())
            {
                temp1.Add(first.Dict[word]);
                temp2.Add(second.Dict[word]);
            }
            foreach (var word in first.Set.Except(second.Set).ToHashSet())
            {
                temp1.Add(first.Dict[word]);
                temp2.Add(0);
            }
            foreach (var word in second.Set.Except(first.Set).ToHashSet())
            {
                temp1.Add(0);
                temp2.Add(second.Dict[word]);
            }
            var vector1 = new Vector(temp1, first.Length);
            var vector2 = new Vector(temp2, second.Length);
            return Vector.Cos(vector1, vector2);
        }
        public int Count => Dict.Count;
    }
}

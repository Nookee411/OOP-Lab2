using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

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
        private SortedDictionary<string, int> Dict; //Dictionary
        private HashSet<string> Set;//All words
        private double Length; //total num of words

        /// <summary>
        /// Initializing empty fields
        /// </summary>
        public Text()
        {
            Length = 0;
            Dict = new SortedDictionary<string, int>();
            Set = new HashSet<string>();
        }

        /// <summary>
        /// Initializing and add adds all text from file.
        /// </summary>
        /// <param name="fileName"></param>
        public Text(string fileName)
        {
            Dict = new SortedDictionary<string, int>();
            Set = new HashSet<string>();
            Length = 0;
            Add(fileName);
        }

        /// <summary>
        /// Adds all text from file to dictionary.
        /// </summary>
        /// <param name="filename"></param>
        public void Add(string filename)
        {
            StreamReader input = new StreamReader(filename);//open stream
            while (!input.EndOfStream) //while its not over
            {
                string text = input.ReadLine(); //read line
                string[] textArr = Regex.Replace(
               new string(text.Where(x => char.IsWhiteSpace(x) || char.IsLetter(x)).Select(char.ToLower)
                   .ToArray()), @"\s+", " ").Split(); //processing line
                Length += textArr.Length;//adding num of words in line to total words
                foreach (string word in textArr)//adding every word
                {
                    if (Dict.ContainsKey(word))
                        Dict[word]++;
                    else
                        Dict[word] = 1;
                    Set.Add(word);
                }
            }
            input.Close();
        }

        /// <summary>
        /// Finds cos between two texts.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static double Cos(Text first, Text second)
        {
            List<double> temp1 = new List<double>();
            List<double> temp2 = new List<double>();
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

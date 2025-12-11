using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = input[0];   // 수강한 과목 수
            int m = input[1];   // 요구하는 과목 수
            int k = input[2];   // 공개한 과목 수
            int t = 0;
            int sum = 0;
            int max = 0;
            int min = 0;

            var list = new List<(string, int)>(n);
            t = n;
            while (t > 0)
            {
                string[] split = Console.ReadLine().Split();
                list.Add((split[0], int.Parse(split[1])));
                t--;
            }

            t = k;
            while (t > 0)
            {
                string key = Console.ReadLine();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Item1.Equals(key))
                    {
                        sum += list[i].Item2;
                        list.RemoveAt(i);
                        i--;
                    }
                }
                t--;
            }

            list.Sort((num1, num2) => { return num1.Item2.CompareTo(num2.Item2); });

            for (int i = 0; i < m - k; i++)
            {
                min += list[i].Item2;
            }
            for (int i = list.Count - 1; i > list.Count - 1 - (m - k); i--)
            {
                max += list[i].Item2;
            }
            Console.WriteLine("{0} {1}", sum + min, sum + max);
        }
    }
}
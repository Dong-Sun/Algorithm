using System.Runtime.InteropServices;
using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // input
            int n = int.Parse(Console.ReadLine());
            int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int m = int.Parse(Console.ReadLine());
            int[] B = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            // sort
            var listA = new List<(int, int)>(n + 1);
            var listB = new List<(int, int)>(m + 1);

            for (int i = 0; i < A.Length; i++)
            {
                listA.Add((A[i], i));
            }
            for (int i = 0; i < B.Length; i++)
            {
                listB.Add((B[i], i));
            }

            listA.Sort((left, right) =>
            {
                if (left.Item1.CompareTo(right.Item1) == 0)
                    return left.Item2.CompareTo(right.Item2);
                else
                    return right.Item1.CompareTo(left.Item1);
            });
            listB.Sort((left, right) =>
            {
                if (left.Item1.CompareTo(right.Item1) == 0)
                    return left.Item2.CompareTo(right.Item2);
                else
                    return right.Item1.CompareTo(left.Item1);
            });

            // greedy
            List<int> result = new List<int>();
            int indexA = 0;
            int indexB = 0;
            int limitA = 0;
            int limitB = 0;
            while (indexA < listA.Count && indexB < listB.Count)
            {
                if (listA[indexA].Item1 == listB[indexB].Item1)
                {
                    limitA = listA[indexA].Item2;
                    limitB = listB[indexB].Item2;
                    result.Add(listA[indexA].Item1);
                    indexA++;
                    indexB++;
                }
                else if (listA[indexA].Item1 > listB[indexB].Item1)
                {
                    indexA++;
                }
                else
                {
                    indexB++;
                }
                while (indexA < listA.Count && listA[indexA].Item2 < limitA)
                {
                    indexA++;
                }
                while (indexB < listB.Count && listB[indexB].Item2 < limitB)
                {
                    indexB++;
                }
            }

            Console.WriteLine(result.Count);
            if (result.Count > 0)
            {
                foreach (var v in result)
                    Console.Write("{0} ", v);
            }
        }
    }
}
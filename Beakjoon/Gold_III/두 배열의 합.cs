using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            long T = long.Parse(Console.ReadLine());
            long[] input;
            long result = 0;

            int n = int.Parse(Console.ReadLine());
            long[] A = new long[n + 1];
            input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            for (long i = 1; i <= n; i++)
                A[i] = input[i - 1];

            int m = int.Parse(Console.ReadLine());
            long[] B = new long[m + 1];
            input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            for (long i = 1; i <= m; i++)
                B[i] = input[i - 1];

            Dictionary<long, long> sumA = new Dictionary<long, long>(n * n);
            for (long i = 1; i <= n; i++)
            {
                long sum = A[i];
                if (sumA.ContainsKey(sum)) sumA[sum]++;
                else sumA.Add(sum, 1);
                for (long j = i + 1; j <= n; j++)
                {
                    sum += A[j];
                    if (sumA.ContainsKey(sum)) sumA[sum]++;
                    else sumA.Add(sum, 1);
                }
            }
            Dictionary<long, long> sumB = new Dictionary<long, long>(m * m);
            for (long i = 1; i <= m; i++)
            {
                long sum = B[i];
                if (sumB.ContainsKey(sum)) sumB[sum]++;
                else sumB.Add(sum, 1);
                for (long j = i + 1; j <= m; j++)
                {
                    sum += B[j];
                    if (sumB.ContainsKey(sum)) sumB[sum]++;
                    else sumB.Add(sum, 1);
                }
            }
            foreach (var v in sumA)
            {
                long find = T - v.Key;
                if (sumB.ContainsKey(find))
                    result += sumB[find] * v.Value;
            }
            Console.WriteLine(result);
        }
    }
}
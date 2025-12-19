using System.Drawing;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = int.Parse(Console.ReadLine());
            long k = long.Parse(Console.ReadLine());

            long left = 0;
            long right = n * n + 1;
            while (left + 1 < right)
            {
                long pivot = (left + right) / 2;
                long cnt = 0;
                for (long i = 1; i <= n; i++)
                {
                    cnt += Math.Min(pivot / i, n);
                }
                if (cnt >= k)
                {
                    right = pivot;
                }
                else
                {
                    left = pivot;
                }
            }
            Console.WriteLine(right);
        }
    }
}
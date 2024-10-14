using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Xml;

namespace Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            // [일, 0 == T, 1 == P]
            int[,] arr = new int[17, 2];
            int[] input;
            for (int i = 1; i <= n; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                arr[i, 0] = input[0];
                arr[i, 1] = input[1];
            }

            int[] dp = new int[17];
            // dp
            for (int i = 1; i <= n; i++)
            {
                if (i + arr[i, 0] <= n + 1)
                    dp[i + arr[i, 0]] = Math.Max(dp[i + arr[i, 0]], dp[i] + arr[i, 1]);
                dp[i + 1] = Math.Max(dp[i + 1], dp[i]);
            }
            Console.WriteLine(dp[n + 1]);
        }
    }
}
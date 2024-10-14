using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Xml;

namespace Debug
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] input = new int[10001];
            for (int i = 1; i <= n; i++)
                input[i] = int.Parse(Console.ReadLine());
            int[] dp = new int[10001];
            dp[1] = input[1];
            dp[2] = input[1] + input[2];
            for (int i = 3; i <= n; i++)
            {
                dp[i] = Math.Max(Math.Max(dp[i - 3] + input[i - 1] + input[i], dp[i - 2] + input[i]), dp[i - 1]);
            }
            Console.WriteLine(dp[n]);
        }
    }
}
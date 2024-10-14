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
            int[] dp = new int[n + 1];
            for (int i = 0; i <= n; i++)
                dp[i] = i;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j * j <= i; j++)
                {
                    dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
                }
            }
            Console.WriteLine(dp[n]);
        }
    }
}
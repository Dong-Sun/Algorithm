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
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int[] dp = new int[n];
            int result = 0;
            dp[0] = input[0];
            result = dp[0];
            for (int i = 1; i < n; i++)
            {
                dp[i] = Math.Max(dp[i - 1] + input[i], input[i]);
                if (dp[i] > result)
                    result = dp[i];
            }
            Console.WriteLine(result);
        }
    }
}
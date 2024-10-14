using System.Reflection;
using System.Reflection.Metadata;
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
            int[] arr = new int[1005];
            int[] dp = new int[1005];
            string[] split = Console.ReadLine().Split();
            for (int i = 1; i <= n; i++)
                arr[i] = Convert.ToInt32(split[i - 1]);
            for (int i = 1; i <= n; i++)
            {
                dp[i] = arr[i];
                for (int j = 1; j < i; j++)
                    dp[i] = Math.Max(dp[i], dp[i - j] + arr[j]);
            }
            Console.WriteLine(dp[n]);
        }
    }
}
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
            string[] split = Console.ReadLine().Split(' ');
            for (int i = 1; i <= n; i++)
                arr[i] = int.Parse(split[i - 1]);

            int result = 0;
            for (int i = 1; i <= n; i++)
            {
                dp[i] = arr[i];
                for (int j = 1; j < i; j++)
                {
                    if (arr[i] > arr[j])
                        dp[i] = Math.Max(dp[i], dp[j] + arr[i]);
                }
                result = Math.Max(result, dp[i]);
            }
            Console.WriteLine(result);
        }
    }
}
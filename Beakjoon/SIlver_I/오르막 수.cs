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
            int[] dp = new int[11];
            for (int i = 1; i <= 10; i++)
                dp[i] = i;
            while (n > 1)
            {
                for (int i = 1; i <= 10; i++)
                    dp[i] = (dp[i] + dp[i - 1]) % 10007;
                n--;
            }
            Console.WriteLine(dp[10]);
        }
    }
}
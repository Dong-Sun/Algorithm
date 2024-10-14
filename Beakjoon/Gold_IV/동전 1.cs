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
            // 1. 가치의 합이 k를 넘으면 안된다.
            // 2. dp[i] = i값이 되기 위한 경우의 수
            // 3. i번째의 경우를 구하기 위해서는 i - 동전의 가치 번째의 경우에 현재 경우를 더한다
            // 4. ex) dp[3] += dp[3 - 1], dp[3 - 2]
            // 5. dp[i] = dp[i] + dp[j - arr[i]];
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), Convert.ToInt32);
            int n = input[0];
            int k = input[1];
            int[] arr = new int[100005];
            int[] dp = new int[100005];
            dp[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
                // arr[i] 가치보다 작은 값은 접근x
                for (int j = arr[i]; j <= k; j++)
                {
                    dp[j] = dp[j - arr[i]] + dp[j];
                }
            }
            System.Console.WriteLine(dp[k]);
        }
    }
}
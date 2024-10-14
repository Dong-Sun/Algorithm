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
            // 감소하는 부분 수열 <- 앞쪽에서 더 큰값과 연산하기
            // 가장 긴 이므로 길이를 기억해야 함(메모이제이션)
            // dp[i]의 상태는 현재 번째의 수가 포함하는 가장 긴 수열
            // 조건) i > j 이면서 arr[i]가 arr[j]보다 작은 값일 때
            // 위 조건을 만족하는 j값을 가진 dp[j] 중 최댓값
            // dp[i] = Max(dp[i], dp[j] + 1)
            int n = int.Parse(Console.ReadLine());
            int[] dp = new int[1005];
            int[] arr = new int[1005];
            string[] split = Console.ReadLine().Split();
            for (int i = 1; i <= n; i++)
                arr[i] = int.Parse(split[i - 1]);
            dp[0] = 0;
            dp[1] = 1;
            int result = 1;
            for (int i = 2; i <= n; i++)
            {
                dp[i] = 1;
                for (int j = 1; j < i; j++)
                {
                    if (arr[i] < arr[j])
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
                result = Math.Max(result, dp[i]);
            }
            Console.WriteLine(result);
        }
    }
}
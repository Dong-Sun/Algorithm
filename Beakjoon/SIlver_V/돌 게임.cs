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
            // 1개 or 3개만 빼올 수 있음
            // == 내 차례에 1개 or 3개가 오게 만들어야 이김
            // dp[i] == 1 or 3 일 때 홀수면 SK, 짝수면 CY
            // 상대가 4가 나오게 만들면 무조건 이김
            // 4로 만드려면 5 or 7 이면 됨
            // 여기까지 정리하면 6 or 8 -> 5 or 7 -> 2 or 4 -> 1 or 3
            // [1, 3] [2, 4] [5, 7] [6, 8]
            // n이 앞쪽에 걸리면(i == 홀수) SK 뒤쪽에 걸리면(i == 짝수) CY
            // dp[i, 0] = dp[i - 2, 0] + 4;
            // dp[i, 1] = dp[i - 2, 1] + 4;

            int n = int.Parse(Console.ReadLine());
            int[,] dp = new int[1005, 2];
            if (n == 1 || n == 3)
            {
                Console.WriteLine("SK");
                return;
            }
            if (n == 2 || n == 4)
            {
                Console.WriteLine("CY");
                return;
            }
            dp[1, 0] = 1; dp[1, 1] = 3;
            dp[2, 0] = 2; dp[2, 1] = 4;
            int index = 0;
            for (int i = 3; i <= n; i++)
            {
                dp[i, 0] = dp[i - 2, 0] + 4;
                dp[i, 1] = dp[i - 2, 1] + 4;
                if (n == dp[i, 0] || n == dp[i, 1])
                {
                    index = i;
                    break;
                }
            }
            if (index % 2 == 1)
                Console.WriteLine("SK");
            else
                Console.WriteLine("CY");
        }
    }
}
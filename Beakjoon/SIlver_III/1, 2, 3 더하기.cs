using System.Text;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution();
        }

        public static void Solution()
        {
            int T = int.Parse(Console.ReadLine());
            int[] dp = new int[11];
            dp[1] = 1;
            dp[2] = 2;
            dp[3] = 4;
            for (int i = 4; i <= 10; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];
            }
            for (int i = 0; i < T; i++)
            {
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine(dp[num]);
            }
        }
    }
}
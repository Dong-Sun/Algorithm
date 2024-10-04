using System.Text;

namespace Solution
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t > 0)
            {
                int n = int.Parse(Console.ReadLine());
                int[,] stickers = new int[2, n + 1];
                int[,] dp = new int[2, n + 1];
                for (int i = 0; i < 2; i++)
                {
                    string[] split = Console.ReadLine().Split();
                    for (int j = 0; j < n; j++)
                    {
                        stickers[i, j + 1] = int.Parse(split[j]);
                    }
                }
                for (int i = 1; i <= n; i++)
                {
                    dp[0, i] = Math.Max(dp[0, i - 1], dp[1, i - 1] + stickers[0, i]);
                    dp[1, i] = Math.Max(dp[1, i - 1], dp[0, i - 1] + stickers[1, i]);
                }
                sb.AppendLine(Math.Max(dp[0, n], dp[1, n]).ToString());
                t--;
            }
            Console.Write(sb);
        }
    }
}
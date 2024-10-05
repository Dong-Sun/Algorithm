using System.Text;

namespace Solution
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static Func<int[]> ConvertToInt = () =>
        {
            return Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        };
        static void Main(string[] args)
        {
            int[] input = ConvertToInt.Invoke();
            int n = input[0];
            int m = input[1];
            int[,] coordinate = new int[m, 4];
            int[,] table = new int[n + 2, n + 2];

            for (int i = 1; i <= n; i++)
            {
                input = ConvertToInt.Invoke();
                for (int j = 0; j < n; j++)
                {
                    table[i, j + 1] = input[j];
                }
            }

            for (int i = 0; i < m; i++)
            {
                input = ConvertToInt.Invoke();
                for (int j = 0; j < 4; j++)
                {
                    coordinate[i, j] = input[j];
                }
            }

            int[,] dp = new int[n + 2, n + 2];
            for (int y = 1; y <= n; y++)
            {
                for (int x = 1; x <= n; x++)
                {
                    dp[y, x] = dp[y - 1, x] + dp[y, x - 1] - dp[y - 1, x - 1] + table[y, x];
                }
            }
            for (int i = 0; i < m; i++)
            {
                int y1 = coordinate[i, 0];
                int x1 = coordinate[i, 1];
                int y2 = coordinate[i, 2];
                int x2 = coordinate[i, 3];

                sb.AppendLine((dp[y2, x2] - dp[y1 - 1, x2] - dp[y2, x1 - 1] + dp[y1 - 1, x1 - 1]).ToString());
            }
            Console.Write(sb);
        }
    }
}
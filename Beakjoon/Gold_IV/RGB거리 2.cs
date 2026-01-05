namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] table = new int[n + 1, 3];
            int[,] dp = new int[n + 1, 3];
            int result = int.MaxValue;
            for (int i = 1; i <= n; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                for (int j = 0; j < 3; j++)
                    table[i, j] = input[j];
            }
            for (int color = 0; color < 3; color++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i == color) dp[1, i] = table[1, i];
                    else dp[1, i] = 987654321;
                }
                for (int i = 2; i <= n; i++)
                {
                    dp[i, 0] = Math.Min(dp[i - 1, 1], dp[i - 1, 2]) + table[i, 0];
                    dp[i, 1] = Math.Min(dp[i - 1, 0], dp[i - 1, 2]) + table[i, 1];
                    dp[i, 2] = Math.Min(dp[i - 1, 0], dp[i - 1, 1]) + table[i, 2];
                }
                for (int i = 0; i < 3; i++)
                {
                    if (i == color) continue;
                    else result = Math.Min(result, dp[n, i]);
                }
            }
            System.Console.WriteLine(result);
        }
    }
}
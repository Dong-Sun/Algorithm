namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] triangle = new int[n + 2, n + 2];
            int[,] dp = new int[n + 2, n + 2];
            for (int i = 1; i <= n; i++)
            {
                string[] split = Console.ReadLine().Split();
                for (int j = 0; j < split.Length; j++)
                {
                    triangle[i, j + 1] = int.Parse(split[j]);
                }
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    dp[i, j] = Math.Max(dp[i - 1, j - 1], dp[i - 1, j]) + triangle[i, j];
                }
            }
            int result = 0;
            for (int i = 1; i <= n; i++)
            {
                if (result < dp[n, i])
                    result = dp[n, i];
            }
            Console.WriteLine(result);
        }
    }
}
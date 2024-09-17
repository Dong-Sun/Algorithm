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
            int n = int.Parse(Console.ReadLine());
            int[] dp = new int[500001];
            for (int i = 1; i <= n; i++)
            {
                dp[i] = dp[i - 1] + 1;
                for (int j = 1; j * j <= i; j++)
                {
                    dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
                }
            }
            Console.WriteLine(dp[n]);
        }
    }
}
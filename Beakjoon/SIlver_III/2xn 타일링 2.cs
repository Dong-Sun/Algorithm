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
            int[] dp = new int[1001];
            dp[1] = 1;
            dp[2] = 3;
            for (int i = 3; i <= n; i++)
                dp[i] = (dp[i - 1] + dp[i - 2] * 2) % 10007;
            Console.WriteLine(dp[n]);
        }
    }
}
namespace Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            int[,] dp = new int[second.Length + 1, first.Length + 1];
            for (int i = 1; i <= second.Length; i++)
            {
                for (int j = 1; j <= first.Length; j++)
                {
                    if (second[i - 1].Equals(first[j - 1]))
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
            Console.WriteLine(dp[second.Length, first.Length]);
        }
    }
}
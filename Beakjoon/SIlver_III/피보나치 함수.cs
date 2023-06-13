namespace ConsoleApp1
{
    class Program
    {
        static int[] dp = new int[45];

        static int fibonacci(int n)
        {
            if (dp[n] != 0 || n == 0) return dp[n];
            else
            {
                dp[n] = fibonacci(n - 1) + fibonacci(n - 2);
                return dp[n];
            }
        }

        static void Main(string[] args)
        {
            dp[0] = 0;
            dp[1] = 1;
            int n = int.Parse(Console.ReadLine());
            int fibo;
            for (int i = 0; i < n; i++)
            {
                fibo = int.Parse(Console.ReadLine());
                if (fibo == 0)
                {
                    Console.WriteLine("1 0");
                    continue;
                }
                Console.WriteLine("{0} {1}", fibonacci(fibo - 1), fibonacci(fibo));
            }

        }
    }
}
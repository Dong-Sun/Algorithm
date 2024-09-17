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
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[301];
            int[] dp = new int[301];
            for (int i = 0; i < n; i++)
                arr[i] = int.Parse(Console.ReadLine());
            dp[0] = arr[0];
            dp[1] = arr[0] + arr[1];
            dp[2] = Max(arr[2] + arr[0], arr[2] + arr[1]);
            for (int i = 3; i < n; i++)
            {
                dp[i] = Max(arr[i] + dp[i - 2], arr[i] + dp[i - 3] + arr[i - 1]);
            }
            Console.WriteLine(dp[n - 1]);
        }
        public static int Max(int num1, int num2)
        {
            return num1 > num2 ? num1 : num2;
        }
    }
}
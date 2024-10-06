using System.Text;

namespace Solution
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static Func<int[]> InputIntArray = () => Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        static Func<int> InputInt = () => int.Parse(Console.ReadLine());
        static void Main(string[] args)
        {
            // input
            int n = InputInt.Invoke();
            int[,] arr = new int[n, 5];
            for (int i = 0; i < n; i++)
            {
                int[] temp = InputIntArray.Invoke();
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j + 1] = temp[j];
                }
            }

            // DP
            int[,] maxDP = new int[n, 5];
            int[,] minDP = new int[n, 5];
            maxDP[0, 1] = minDP[0, 1] = arr[0, 1];
            maxDP[0, 2] = minDP[0, 2] = arr[0, 2];
            maxDP[0, 3] = minDP[0, 3] = arr[0, 3];
            maxDP[0, 0] = -1;
            maxDP[0, 4] = -1;
            minDP[0, 0] = int.MaxValue;
            minDP[0, 4] = int.MaxValue;
            for (int i = 1; i < n; i++)
            {
                maxDP[i, 0] = -1;
                maxDP[i, 4] = -1;
                minDP[i, 0] = int.MaxValue;
                minDP[i, 4] = int.MaxValue;
                for (int j = 1; j <= 3; j++)
                {
                    maxDP[i, j] = Math.Max(Math.Max(maxDP[i - 1, j - 1], maxDP[i - 1, j]), maxDP[i - 1, j + 1]) + arr[i, j];
                    minDP[i, j] = Math.Min(Math.Min(minDP[i - 1, j - 1], minDP[i - 1, j]), minDP[i - 1, j + 1]) + arr[i, j];
                }
            }

            // Print
            int max = Math.Max(Math.Max(maxDP[n - 1, 1], maxDP[n - 1, 2]), maxDP[n - 1, 3]);
            int min = Math.Min(Math.Min(minDP[n - 1, 1], minDP[n - 1, 2]), minDP[n - 1, 3]);
            sb.Append($"{max} {min}");
            Console.Write(sb);
        }
    }
}
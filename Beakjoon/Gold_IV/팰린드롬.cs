using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static Func<int[]> InputIntArray = () => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        static Func<int> InputInt = () => int.Parse(Console.ReadLine());

        static void Main(string[] args)
        {
            int n = InputInt();
            int[] arr = InputIntArray();
            int[] table = new int[n + 1];
            for (int i = 0; i < n; i++)
                table[i + 1] = arr[i];
            int[,] dp = new int[n + 1, n + 1];
            for (int i = 1; i <= n; i++)
                dp[i, i] = 1;
            for (int i = n; i > 0; i--)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    if (table[i] == table[j])
                    {
                        if (j - i == 1) dp[i, j] = 1;
                        else if (dp[i + 1, j - 1] == 1) dp[i, j] = 1;
                    }
                }
            }
            int m = InputInt();
            while (m-- > 0)
            {
                arr = InputIntArray();
                int s = arr[0];
                int e = arr[1];
                sb.AppendLine(dp[s, e].ToString());
            }
            Console.WriteLine(sb);
        }
    }
}
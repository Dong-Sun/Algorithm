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
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            int[,] dp = new int[first.Length + 2, second.Length + 2];
            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    if (first[i - 1].Equals(second[j - 1])) dp[i, j] = dp[i - 1, j - 1] + 1;
                    else dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
            sb.AppendLine(dp[first.Length, second.Length].ToString());
            if (dp[first.Length, second.Length] <= 0)
            {
                Console.WriteLine(sb);
                return;
            }
            int y = first.Length;
            int x = second.Length;
            var s = new Stack<char>();
            while (y >= 1 && x >= 1)
            {
                if (dp[y, x] == 0)
                    break;
                if (dp[y, x - 1] != dp[y, x])
                {
                    if (dp[y - 1, x] != dp[y, x])
                    {
                        x--;
                        y--;
                        s.Push(first[y]);
                    }
                    else
                        y--;
                }
                else
                    x--;
            }
            while (s.Count > 0)
                sb.Append(s.Pop());
            Console.WriteLine(sb);
        }
    }
}
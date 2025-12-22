using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static int[] dp;
        static List<List<int>> edges = new List<List<int>>();
        static bool[] visited;
        static void Main(string[] args)
        {
            // input
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = input[0];   // 정점의 수
            int r = input[1];   // 루트의 번호
            int q = input[2];   // 쿼리의 수
            dp = new int[n + 1];
            for (int i = 0; i <= n; i++)
                edges.Add(new List<int>());
            for (int i = 1; i < n; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                edges[input[0]].Add(input[1]);
                edges[input[1]].Add(input[0]);
            }

            // dfs
            visited = new bool[n + 1];
            visited[r] = true;
            Dfs(r);
            for (int i = 0; i < q; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sb.AppendLine(dp[num].ToString());
            }
            Console.WriteLine(sb);
        }

        static int Dfs(int n)
        {
            int sum = 0;
            foreach (var v in edges[n])
            {
                if (visited[v])
                    continue;
                visited[v] = true;
                sum += Dfs(v);
            }
            return dp[n] = sum + 1;
        }
    }
}
using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static StreamReader sr = new StreamReader(Console.OpenStandardInput());
        static int n;
        static long[] weight;
        static List<int>[] edges;
        static bool[] visited;
        static void Main(string[] args)
        {
            // 입력
            n = int.Parse(sr.ReadLine());
            weight = new long[n + 1];
            visited = new bool[n + 1];
            edges = new List<int>[n + 1];
            for (int i = 0; i <= n; i++)
                edges[i] = new List<int>();
            string[] split;
            for (int i = 2; i <= n; i++)
            {
                split = sr.ReadLine().Split();
                if (split[0].Equals("S"))
                    weight[i] = int.Parse(split[1]);
                else
                    weight[i] = -int.Parse(split[1]);

                edges[int.Parse(split[2])].Add(i);
            }
            // 구현
            long result = Dfs(1);

            // 출력
            Console.WriteLine(result);
        }
        static long Dfs(int start)
        {
            visited[start] = true;
            long w = weight[start];
            foreach (var v in edges[start])
            {
                if (visited[v]) continue;
                w += Dfs(v);
            }
            return Math.Max(w, 0);
        }
    }
}
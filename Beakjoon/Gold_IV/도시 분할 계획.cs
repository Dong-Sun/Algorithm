using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static Func<int[]> InputIntArray = () => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        static Func<int> InputInt = () => int.Parse(Console.ReadLine());
        static int[] parent;
        static int[] rank;
        static int n;  // 집의 개수
        static int m;  // 길의 개수
        static int result = 0;
        static int max = 0;
        static void Main(string[] args)
        {
            // input
            int[] input = InputIntArray();
            n = input[0];
            m = input[1];

            var edges = new PriorityQueue<(int, int, int), int>(m + 1);  // 경로

            for (int i = 0; i < m; i++)
            {
                input = InputIntArray();
                int start = input[0];
                int end = input[1];
                int cost = input[2];
                edges.Enqueue((start, end, cost), cost);
            }

            // Union-Find
            rank = new int[n + 1];
            parent = new int[n + 1];
            for (int i = 1; i <= n; i++)
                parent[i] = i;
            while (edges.Count > 0)
            {
                var item = edges.Dequeue();
                int left = item.Item1;
                int right = item.Item2;
                int cost = item.Item3;

                left = Find(left);
                right = Find(right);
                Union(left, right, cost);
            }
            Console.WriteLine(result - max);
        }

        static int Find(int n)
        {
            if (n != parent[n])
                parent[n] = Find(parent[n]);
            return parent[n];
        }

        static void Union(int left, int right, int cost)
        {
            int a = Find(left);
            int b = Find(right);
            if (a == b)
                return;
            if (rank[a] == rank[b])
            {
                parent[b] = a;
                rank[a]++;
            }
            else if (rank[a] > rank[b])
                parent[b] = a;
            else
                parent[a] = b;
            result += cost;
            max = Math.Max(max, cost);
        }
    }
}
using System.Text;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            int temp = n;
            int[] parent = new int[n + 2];
            bool[] visited = new bool[n + 2];
            List<List<int>> tree = new List<List<int>>();
            for (int i = 0; i <= n; i++)
            {
                tree.Add(new List<int>());
            }
            while (temp - 1 > 0)
            {
                temp--;
                string[] split = Console.ReadLine().Split();
                int left = int.Parse(split[0]);
                int right = int.Parse(split[1]);
                tree[left].Add(right);
                tree[right].Add(left);
            }
            var bfs = new Queue<int>();
            bfs.Enqueue(1);
            visited[1] = true;
            while (bfs.Count > 0)
            {
                int node = bfs.Dequeue();
                foreach (int num in tree[node])
                {
                    if (visited[num])
                        continue;
                    bfs.Enqueue(num);
                    visited[num] = true;
                    parent[num] = node;
                }
            }

            for (int i = 2; i <= n; i++)
            {
                sb.AppendLine(parent[i].ToString());
            }
            Console.Write(sb);
        }
    }
}
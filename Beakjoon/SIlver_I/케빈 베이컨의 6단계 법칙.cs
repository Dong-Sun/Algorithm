using System.Security.Cryptography;

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
            string[] split = Console.ReadLine().Split();
            int n = int.Parse(split[0]);
            int m = int.Parse(split[1]);
            int[,] distance = new int[n + 1, n + 1];
            bool[] visited;
            List<List<int>> edge = new List<List<int>>(n + 1);
            for (int i = 0; i <= n; i++)
                edge.Add(new List<int>(n + 1));

            for (int i = 0; i < m; i++)
            {
                split = Console.ReadLine().Split();
                int left = int.Parse(split[0]);
                int right = int.Parse(split[1]);
                edge[left].Add(right);
                edge[right].Add(left);
            }

            Queue<(int, int)> bfs = new Queue<(int, int)>();
            for (int i = 1; i <= n; i++)
            {
                visited = new bool[n + 1];
                bfs.Enqueue((i, 0));
                while (bfs.Count > 0)
                {
                    (int, int) e = bfs.Dequeue();
                    int curEdge = e.Item1;
                    int curDistance = e.Item2;
                    if (visited[curEdge])
                        continue;
                    visited[curEdge] = true;
                    distance[i, curEdge] = curDistance;
                    foreach (int num in edge[curEdge])
                        bfs.Enqueue((num, curDistance + 1));
                }
            }
            int min = int.MaxValue;
            int sum;
            int result = 0;
            for (int i = 1; i <= n; i++)
            {
                sum = 0;
                for (int j = 1; j <= n; j++)
                    sum += distance[i, j];

                if (sum < min)
                {
                    min = sum;
                    result = i;
                }
            }
            Console.WriteLine(result);
        }
    }
}
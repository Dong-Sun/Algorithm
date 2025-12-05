using System.Reflection.Metadata;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m, r;
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            n = input[0];
            m = input[1];
            r = input[2];

            int[] t = new int[n + 1];
            input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            for (int i = 0; i < n; i++)
                t[i + 1] = input[i];

            int[,] graph = new int[n + 1, n + 1];
            for (int i = 0; i <= n; i++)
                for (int j = 0; j <= n; j++)
                    graph[i, j] = -1;

            for (int i = 0; i < r; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                graph[input[0], input[1]] = input[2];
                graph[input[1], input[0]] = input[2];
            }

            int result = 0;
            var s = new PriorityQueue<(int, int), int>();    // ((현재 위치, 지금까지 이동한 거리), 우선순위)
            for (int i = 1; i <= n; i++)
            {
                s.Enqueue((i, 0), 0);
                bool[] visited = new bool[n + 1];
                int count = 0;

                while (s.Count > 0)
                {
                    (int, int) item = s.Dequeue();
                    int cur = item.Item1;
                    int distance = item.Item2;

                    if (visited[cur])
                        continue;
                    visited[cur] = true;
                    count = count + t[cur];

                    for (int next = 1; next <= n; next++)
                        if (visited[next] == false && graph[cur, next] != -1 && distance + graph[cur, next] <= m)
                            s.Enqueue((next, distance + graph[cur, next]), distance + graph[cur, next]);
                }
                if (result < count)
                    result = count;
            }
            Console.WriteLine(result);
        }
    }
}
namespace Debug
{
    class Program
    {
        static Func<int[]> InputIntArray = () => Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        static Func<int> InputInt = () => int.Parse(Console.ReadLine());
        static int[,] distance;
        static List<List<int>> edge;
        static void Main(string[] args)
        {
            int[] input = InputIntArray();
            int n = input[0];
            int e = input[1];
            int v1, v2;
            distance = new int[n + 1, n + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == j) // 자기 자신
                        continue;
                    distance[i, j] = int.MaxValue;
                }
            }
            edge = new List<List<int>>();
            for (int i = 0; i <= n; i++)
                edge.Add(new List<int>());

            int temp = e;
            while (temp > 0)
            {
                input = InputIntArray();
                int start = input[0];
                int end = input[1];
                int dis = input[2];
                edge[start].Add(end);
                edge[end].Add(start);
                distance[start, end] = dis;
                distance[end, start] = dis;

                temp--;
            }
            input = InputIntArray();
            v1 = input[0];
            v2 = input[1];
            Dijkstra(1);
            Dijkstra(v1);
            Dijkstra(v2);
            int result = -1;

            if (distance[1, v1] != int.MaxValue && distance[v1, v2] != int.MaxValue && distance[v2, n] != int.MaxValue)
                result = distance[1, v1] + distance[v1, v2] + distance[v2, n];
            if (distance[1, v1] != int.MaxValue && distance[v1, v2] != int.MaxValue && distance[v2, n] != int.MaxValue)
            {
                int case2 = distance[1, v2] + distance[v2, v1] + distance[v1, n];
                if (result == -1)
                    result = case2;
                else
                    result = case2 < result ? case2 : result;
            }
            if (result > 0)
                Console.WriteLine(result);
            else
                Console.WriteLine("-1");
        }
        static void Dijkstra(int start)
        {
            PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();
            pq.Enqueue((start, 0), 0);
            while (pq.Count > 0)
            {
                (int, int) cur = pq.Dequeue();
                int index = cur.Item1;
                int dis = cur.Item2;
                if (dis > distance[start, index])
                    continue;
                foreach (var next in edge[index])
                {
                    int priority = dis + distance[index, next];
                    if (priority <= distance[start, next])
                    {
                        distance[start, next] = priority;
                        distance[next, start] = priority;
                        pq.Enqueue((next, priority), -priority);
                    }
                }
            }
        }
    }
}

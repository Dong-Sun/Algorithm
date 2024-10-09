using System.Text;

namespace Debug
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static Func<int[]> InputIntArray = () => Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        static Func<int> InputInt = () => int.Parse(Console.ReadLine());
        static void Main(string[] args)
        {
            int[] input = InputIntArray();
            int v = input[0];   // 정점의 개수
            int e = input[1];   // 간선의 개수
            int start = InputInt();

            var edge = new List<List<(int, int)>>();
            for (int i = 0; i <= v; i++)
                edge.Add(new List<(int, int)>());

            int[] distance = new int[v + 1];
            for (int i = 1; i <= v; i++)
            {
                if (i != start)
                    distance[i] = -1;
            }

            int temp = e;
            while (temp > 0)
            {
                input = InputIntArray();
                int begin = input[0];
                int end = input[1];
                int weight = input[2];
                edge[begin].Add((end, weight));
                temp--;
            }

            bool[] visited = new bool[v + 1];
            PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();
            pq.Enqueue((start, 0), 0);
            while (pq.Count > 0)
            {
                (int, int) cur = pq.Dequeue();
                int vertex = cur.Item1;
                int dis = cur.Item2;
                if (dis > distance[vertex])
                    continue;
                if (visited[vertex])
                    continue;
                visited[vertex] = true;
                foreach (var next in edge[vertex])
                {
                    int nextDistance = dis + next.Item2;
                    if (visited[next.Item1])
                        continue;
                    if (nextDistance < distance[next.Item1] || distance[next.Item1] == -1)
                    {
                        distance[next.Item1] = nextDistance;
                        pq.Enqueue((next.Item1, nextDistance), nextDistance);
                    }
                }
            }

            for (int i = 1; i <= v; i++)
            {
                int num = distance[i];
                if (num != -1)
                    sb.AppendLine($"{num}");
                else
                    sb.AppendLine("INF");
            }
            Console.Write(sb);
        }
    }
}
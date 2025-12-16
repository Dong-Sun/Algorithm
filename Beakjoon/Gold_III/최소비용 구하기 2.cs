using System.Runtime.InteropServices;
using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(input);
            var edges = new List<List<(int, int)>>();    // [start] => (end, dist)
            for (int i = 0; i <= n; i++)
                edges.Add(new List<(int, int)>());
            input = Console.ReadLine();
            int m = int.Parse(input);
            while (m-- > 0)
            {
                int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int cur = arr[0];
                int next = arr[1];
                int dist = arr[2];
                edges[cur].Add((next, dist));
            }
            int[] temp = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int start = temp[0];
            int end = temp[1];
            int[] distance = new int[n + 1];
            for (int i = 0; i <= n; i++)
                distance[i] = int.MaxValue;
            distance[start] = 0;
            var pq = new PriorityQueue<(int, int, string), int>(); // cur, dist, path, priority
            pq.Enqueue((start, 0, Convert.ToString(start)), 0);
            string way = "";
            while (pq.Count > 0)
            {
                var item = pq.Dequeue();
                int cur = item.Item1;
                int cost = item.Item2;
                string path = item.Item3;
                if (cur == end)
                {
                    way = path;
                    break;
                }
                for (int i = 0; i < edges[cur].Count; i++)
                {
                    int node = edges[cur][i].Item1;
                    int dist = edges[cur][i].Item2;
                    if (distance[node] > dist + cost)
                    {
                        pq.Enqueue((node, dist + cost, path + " " + Convert.ToString(node)), dist + cost);
                        distance[node] = dist + cost;
                    }
                }
            }
            Console.WriteLine(distance[end]);
            string[] split = way.Split();
            Console.WriteLine(split.Length);
            Console.WriteLine(way);
        }
    }
}
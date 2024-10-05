using System.Text;

namespace Solution
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static Func<int[]> ConvertToIntArray = () =>
        {
            return Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        };
        static void Main(string[] args)
        {
            int[] input;
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            var node = new List<List<(int, int)>>();
            for (int i = 0; i <= n; i++)
                node.Add(new List<(int, int)>());

            int[] distance = new int[n + 1];
            for (int i = 0; i <= n; i++)
                distance[i] = -1;

            int temp = m;
            while (temp > 0)
            {
                input = ConvertToIntArray();
                int start = input[0];
                int end = input[1];
                int dist = input[2];
                node[start].Add((end, dist));
                temp--;
            }

            input = ConvertToIntArray();
            int s = input[0];
            int e = input[1];
            distance[s] = 0;
            PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();
            pq.Enqueue((s, 0), 0);
            while (pq.Count > 0)
            {
                (int, int) cur = pq.Dequeue();
                int index = cur.Item1;
                int dist = cur.Item2;
                if (distance[index] < dist)
                    continue;
                foreach (var v in node[index])
                {
                    int next = v.Item1;
                    int nextDist = v.Item2 + dist;
                    if (distance[next] == -1 || nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        pq.Enqueue((next, nextDist), -nextDist);

                    }
                }
            }
            Console.WriteLine(distance[e]);
        }
    }
}
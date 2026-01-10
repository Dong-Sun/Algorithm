using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static StreamReader sr = new StreamReader(Console.OpenStandardInput());
        static void Main(string[] args)
        {
            // 입력
            int n = int.Parse(sr.ReadLine());
            string[] s;
            int start = 0;
            int end = 25;
            List<List<int>> edges = new();          // 경로
            int[,] capacity = new int[53, 53];      // 용량
            int[,] flow = new int[53, 53];          // 유량
            int[] d = new int[53];                  // 지나온 길
            for (int i = 0; i < 53; i++)
                edges.Add(new List<int>());

            while (n-- > 0)
            {
                s = sr.ReadLine().Split();
                char left = char.Parse(s[0]);
                char right = char.Parse(s[1]);
                int x, y;
                if (left >= 'A' && left <= 'Z')
                    x = left - 'A';
                else
                    x = left - 'a' + 26;
                if (right >= 'A' && right <= 'Z')
                    y = right - 'A';
                else
                    y = right - 'a' + 26;

                edges[x].Add(y);
                edges[y].Add(x);
                capacity[x, y] += int.Parse(s[2]);
                capacity[y, x] += int.Parse(s[2]);
            }

            // 구현
            int result = 0;
            while (true)
            {
                for (int i = 0; i < 53; i++)
                    d[i] = i;
                Queue<int> q = new();
                q.Enqueue(start);
                while (q.Count > 0)
                {
                    int cur = q.Dequeue();
                    foreach (var next in edges[cur])
                    {
                        if (d[next] == next && capacity[cur, next] - flow[cur, next] > 0)
                        {
                            q.Enqueue(next);
                            d[next] = cur;
                            if (next == end) break;
                        }
                    }
                }

                if (d[end] == end) break;

                int maxflow = int.MaxValue;
                for (int cur = end; cur != start; cur = d[cur])
                    maxflow = Math.Min(maxflow, capacity[d[cur], cur] - flow[d[cur], cur]);
                for (int cur = end; cur != start; cur = d[cur])
                {
                    flow[d[cur], cur] += maxflow;
                    flow[cur, d[cur]] -= maxflow;
                }

                result += maxflow;
            }

            // 출력
            Console.WriteLine(result);
        }
    }
}
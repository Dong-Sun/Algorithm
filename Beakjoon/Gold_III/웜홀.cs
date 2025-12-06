using System.Diagnostics;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int tc = int.Parse(Console.ReadLine());
            while (tc > 0)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int n = input[0];   // 지점의 수
                int m = input[1];   // 도로의 수
                int w = input[2];   // 웜홀의 수

                long[] dist = new long[n + 1];
                Array.Fill(dist, 10005);
                List<(int, int, int)> edges = new List<(int, int, int)>(m + n);  // from, to, cost

                // 도로 연결
                while (m > 0)
                {
                    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                    edges.Add((input[0], input[1], input[2]));
                    edges.Add((input[1], input[0], input[2]));
                    m--;
                }

                // 웜홀 연결
                while (w > 0)
                {
                    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                    edges.Add((input[0], input[1], -input[2]));
                    w--;
                }

                bool result = false;
                // 벨만포드
                for (int i = 1; i <= n; i++)
                {
                    foreach (var e in edges)
                    {
                        int from = e.Item1;
                        int to = e.Item2;
                        int cost = e.Item3;

                        if (dist[to] > dist[from] + cost)
                        {
                            dist[to] = dist[from] + cost;
                            if (i == n)
                                result = true;
                        }
                    }
                }

                if (result)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");

                tc--;
            }
        }
    }
}
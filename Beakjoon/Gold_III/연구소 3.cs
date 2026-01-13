using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new();
        static StreamReader sr = new(Console.OpenStandardInput());
        static int n, m;
        static int[,] map;
        static bool[,] visited;
        static List<(int y, int x, int time)> virus = new();
        static int[] select;
        static int[] input;
        static int count = 0;
        static int result = int.MaxValue;
        static Queue<(int y, int x, int time)> q = new();
        static void Main(string[] args)
        {
            // 입력
            input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            n = input[0];   // 크기
            m = input[1];   // 바이러스 개수
            map = new int[n + 2, n + 2];
            select = new int[m];
            for (int i = 0; i < n; i++)
            {
                input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int j = 0; j < n; j++)
                {
                    map[i + 1, j + 1] = input[j];
                    if (input[j] == 2)
                        virus.Add((i + 1, j + 1, 0));
                    else if (input[j] == 0)
                        count++;
                }
            }

            // 구현
            // 백트레킹으로 바이러스 시작위치의 모든 경우의 수를 구한다.
            // 각 경우에서 Bfs를 돌려서 바이러스를 퍼트린다.
            Comb(0, 0);

            // 출력
            if (result == int.MaxValue)
                Console.WriteLine("-1");
            else
                Console.WriteLine(result);
        }
        static void Comb(int index, int depth)
        {
            if (depth >= m)
            {
                visited = new bool[n + 2, n + 2];
                for (int i = 0; i < m; i++)
                {
                    int s = select[i];
                    q.Enqueue(virus[s]);
                    visited[virus[s].y, virus[s].x] = true;

                }
                int max = 0;
                int expand = 0;
                while (q.Count > 0)
                {
                    var cur = q.Dequeue();
                    if (map[cur.y, cur.x] == 0)
                        max = Math.Max(max, cur.time);
                    if (cur.y + 1 <= n && !visited[cur.y + 1, cur.x] && map[cur.y + 1, cur.x] != 1)
                    {
                        q.Enqueue((cur.y + 1, cur.x, cur.time + 1));
                        visited[cur.y + 1, cur.x] = true;
                        if (map[cur.y + 1, cur.x] == 0)
                            expand++;
                    }
                    if (cur.y - 1 > 0 && !visited[cur.y - 1, cur.x] && map[cur.y - 1, cur.x] != 1)
                    {
                        q.Enqueue((cur.y - 1, cur.x, cur.time + 1));
                        visited[cur.y - 1, cur.x] = true;
                        if (map[cur.y - 1, cur.x] == 0)
                            expand++;
                    }
                    if (cur.x + 1 <= n && !visited[cur.y, cur.x + 1] && map[cur.y, cur.x + 1] != 1)
                    {
                        q.Enqueue((cur.y, cur.x + 1, cur.time + 1));
                        visited[cur.y, cur.x + 1] = true;
                        if (map[cur.y, cur.x + 1] == 0)
                            expand++;
                    }
                    if (cur.x - 1 > 0 && !visited[cur.y, cur.x - 1] && map[cur.y, cur.x - 1] != 1)
                    {
                        q.Enqueue((cur.y, cur.x - 1, cur.time + 1));
                        visited[cur.y, cur.x - 1] = true;
                        if (map[cur.y, cur.x - 1] == 0)
                            expand++;
                    }
                }
                if (count - expand == 0)
                    result = Math.Min(result, max);
                return;
            }
            for (int i = index; i < virus.Count; i++)
            {
                select[depth] = i;
                Comb(i + 1, depth + 1);
            }
        }
    }
}
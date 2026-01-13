using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new();
        static int n, m, k;
        static int[,] map;
        static bool[,,] visited;
        static int[] dirY = { 1, 0, -1, 0 };
        static int[] dirX = { 0, 1, 0, -1 };
        static int result = -1;
        static void Main(string[] args)
        {
            // 입력
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            n = input[0];
            m = input[1];
            k = input[2];
            map = new int[n + 2, m + 2];
            visited = new bool[n + 2, m + 2, k + 1];
            for (int i = 1; i <= n; i++)
            {
                string s = Console.ReadLine();
                for (int j = 0; j < s.Length; j++)
                    map[i, j + 1] = int.Parse(s[j].ToString());
            }

            // 구현
            Queue<(int y, int x, int ignore, int distance)> q = new();
            q.Enqueue((1, 1, k, 1));
            while (q.Count > 0)
            {
                var cur = q.Dequeue();
                int y = cur.y;
                int x = cur.x;
                int ignore = cur.ignore;
                int distance = cur.distance;
                if (y == n && x == m)
                {
                    result = distance;
                    break;
                }
                for (int i = 0; i < 4; i++)
                {
                    if (y + dirY[i] > n || y + dirY[i] <= 0 || x + dirX[i] > m || x + dirX[i] <= 0)
                        continue;
                    if (!visited[y + dirY[i], x + dirX[i], ignore])
                    {
                        if (map[y + dirY[i], x + dirX[i]] == 0)
                        {
                            q.Enqueue((y + dirY[i], x + dirX[i], ignore, distance + 1));
                            visited[y + dirY[i], x + dirX[i], ignore] = true;
                        }
                        else if (ignore > 0 && !visited[y + dirY[i], x + dirX[i], ignore - 1])
                        {
                            q.Enqueue((y + dirY[i], x + dirX[i], ignore - 1, distance + 1));
                            visited[y + dirY[i], x + dirX[i], ignore - 1] = true;
                        }
                    }
                }
            }

            // 출력
            Console.WriteLine(result);
        }
    }
}
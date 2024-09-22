using System.Text;

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
            StringBuilder sb = new StringBuilder();
            string[] split = Console.ReadLine().Split();
            int n = int.Parse(split[0]);
            int m = int.Parse(split[1]);
            int y = 0;
            int x = 0;
            int[,] table = new int[n + 2, m + 2];
            for (int i = 1; i <= n; i++)
            {
                split = Console.ReadLine().Split();
                for (int j = 0; j < m; j++)
                {
                    table[i, j + 1] = int.Parse(split[j]);
                    if (table[i, j + 1] == 2)
                    {
                        y = i;
                        x = j + 1;
                    }
                    else
                        table[i, j + 1] = -table[i, j + 1];
                }
            }
            Queue<(int, int, int)> bfs = new Queue<(int, int, int)>();
            bool[,] visited = new bool[n + 2, m + 2];

            bfs.Enqueue((y, x, 0));
            while (bfs.Count > 0)
            {
                (int, int, int) cur = bfs.Dequeue();
                int ypos = cur.Item1;
                int xpos = cur.Item2;
                int distance = cur.Item3;
                if (ypos > n || ypos <= 0)
                    continue;
                if (xpos > m || xpos <= 0)
                    continue;
                if (table[ypos, xpos] == 0)
                    continue;
                if (visited[ypos, xpos])
                    continue;
                visited[ypos, xpos] = true;
                table[ypos, xpos] = distance;
                bfs.Enqueue((ypos + 1, xpos, distance + 1));
                bfs.Enqueue((ypos - 1, xpos, distance + 1));
                bfs.Enqueue((ypos, xpos + 1, distance + 1));
                bfs.Enqueue((ypos, xpos - 1, distance + 1));
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    sb.Append(table[i, j] + " ");
                }
                sb.Append('\n');
            }
            Console.Write(sb.ToString());
        }
    }
}
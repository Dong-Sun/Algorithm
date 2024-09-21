using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

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
            string[] split = Console.ReadLine().Split();
            int n = int.Parse(split[0]);
            int m = int.Parse(split[1]);
            bool[,] visited = new bool[n + 2, m + 2];
            char[,] milo = new char[n + 2, m + 2];
            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < m; j++)
                    milo[i, j + 1] = input[j];
            }
            //     y    x    distance
            Queue<(int, int, int)> bfs = new Queue<(int, int, int)>();
            bfs.Enqueue((1, 1, 1));
            while (bfs.Count > 0)
            {
                (int, int, int) cur = bfs.Dequeue();
                int y = cur.Item1;
                int x = cur.Item2;
                int distance = cur.Item3;
                if (y == n && x == m)
                {
                    Console.WriteLine(distance);
                    break;
                }
                if (y > n || y <= 0)
                    continue;
                if (x > m || x <= 0)
                    continue;
                if (milo[y, x].Equals('0'))
                    continue;
                if (visited[y, x])
                    continue;
                visited[y, x] = true;

                bfs.Enqueue((y + 1, x, distance + 1));
                bfs.Enqueue((y - 1, x, distance + 1));
                bfs.Enqueue((y, x + 1, distance + 1));
                bfs.Enqueue((y, x - 1, distance + 1));
            }
        }
    }
}
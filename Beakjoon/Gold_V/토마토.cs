using System.Data.SqlTypes;
using System.Text;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] split = Console.ReadLine().Split();
            int m = int.Parse(split[0]); // 가로
            int n = int.Parse(split[1]); // 세로
            int h = int.Parse(split[2]); // 높이
            int result = 0;
            int zero = 0;
            int[,,] tomato = new int[h + 2, n + 2, m + 2];
            bool[,,] visited = new bool[h + 2, n + 2, m + 2];
            Queue<(int, int, int, int)> q = new Queue<(int, int, int, int)>();
            for (int i = 1; i <= h; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    split = Console.ReadLine().Split(' ');
                    for (int k = 1; k <= m; k++)
                    {
                        tomato[i, j, k] = int.Parse(split[k - 1]);
                        if (tomato[i, j, k] == 1)
                            q.Enqueue((i, j, k, 0));
                        else if (tomato[i, j, k] == 0)
                            zero++;
                    }
                }
            }
            if (zero == 0)
            {
                Console.WriteLine("0");
                return;
            }
            while (q.Count > 0)
            {
                (int, int, int, int) cur = q.Dequeue();
                int height = cur.Item1;
                int col = cur.Item2;
                int row = cur.Item3;
                int distance = cur.Item4;
                if (height > h || height <= 0)
                    continue;
                if (col > n || col <= 0)
                    continue;
                if (row > m || row <= 0)
                    continue;
                if (tomato[height, col, row] == -1)
                    continue;
                if (visited[height, col, row])
                    continue;
                visited[height, col, row] = true;
                if (tomato[height, col, row] == 0)
                {
                    tomato[height, col, row] = distance;
                    if (result < distance)
                        result = distance;
                    zero--;
                }
                q.Enqueue((height + 1, col, row, distance + 1));
                q.Enqueue((height - 1, col, row, distance + 1));
                q.Enqueue((height, col + 1, row, distance + 1));
                q.Enqueue((height, col - 1, row, distance + 1));
                q.Enqueue((height, col, row + 1, distance + 1));
                q.Enqueue((height, col, row - 1, distance + 1));
            }
            if (zero == 0)
                Console.WriteLine(result);
            else
                Console.WriteLine("-1");
        }
    }
}
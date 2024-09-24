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
            int result = 0;
            int zero = 0;
            int[,] tomato = new int[n + 2, m + 2];
            bool[,] visited = new bool[n + 2, m + 2];
            Queue<(int, int, int)> q = new Queue<(int, int, int)>();
            for (int j = 1; j <= n; j++)
            {
                split = Console.ReadLine().Split(' ');
                for (int k = 1; k <= m; k++)
                {
                    tomato[j, k] = int.Parse(split[k - 1]);
                    if (tomato[j, k] == 1)
                        q.Enqueue((j, k, 0));
                    else if (tomato[j, k] == 0)
                        zero++;
                }
            }
            if (zero == 0)
            {
                Console.WriteLine("0");
                return;
            }
            while (q.Count > 0)
            {
                (int, int, int) cur = q.Dequeue();
                int col = cur.Item1;
                int row = cur.Item2;
                int distance = cur.Item3;
                if (col > n || col <= 0)
                    continue;
                if (row > m || row <= 0)
                    continue;
                if (tomato[col, row] == -1)
                    continue;
                if (visited[col, row])
                    continue;
                visited[col, row] = true;
                if (tomato[col, row] == 0)
                {
                    tomato[col, row] = distance;
                    if (result < distance)
                        result = distance;
                    zero--;
                }
                q.Enqueue((col + 1, row, distance + 1));
                q.Enqueue((col - 1, row, distance + 1));
                q.Enqueue((col, row + 1, distance + 1));
                q.Enqueue((col, row - 1, distance + 1));
            }
            if (zero == 0)
                Console.WriteLine(result);
            else
                Console.WriteLine("-1");
        }
    }
}
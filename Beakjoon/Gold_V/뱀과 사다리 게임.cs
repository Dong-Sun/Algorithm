using System.Data.SqlTypes;
using System.Text;
using Microsoft.VisualBasic;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] split = Console.ReadLine().Split(' ');
            int n = int.Parse(split[0]);
            int m = int.Parse(split[1]);
            bool[] visited = new bool[102];
            int[] table = new int[102];
            for (int i = 0; i < n + m; i++)
            {
                split = Console.ReadLine().Split(' ');
                int from = int.Parse(split[0]);
                int to = int.Parse(split[1]);
                table[from] = to;
            }
            Queue<(int, int)> bfs = new Queue<(int, int)>();
            bfs.Enqueue((1, 0));
            while (bfs.Count > 0)
            {
                (int, int) cur = bfs.Dequeue();
                int pos = cur.Item1;
                int count = cur.Item2;
                if (pos == 100)
                {
                    Console.WriteLine(count);
                    break;
                }
                else if (pos > 100)
                    continue;
                else if (visited[pos])
                    continue;
                visited[pos] = true;
                if (table[pos] != 0)
                    pos = table[pos];
                bfs.Enqueue((pos + 1, count + 1));
                bfs.Enqueue((pos + 2, count + 1));
                bfs.Enqueue((pos + 3, count + 1));
                bfs.Enqueue((pos + 4, count + 1));
                bfs.Enqueue((pos + 5, count + 1));
                bfs.Enqueue((pos + 6, count + 1));
            }
        }
    }
}
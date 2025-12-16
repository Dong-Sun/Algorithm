using System.Runtime.InteropServices;
using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dirY = { 1, -1, 0, 0 };
            int[] dirX = { 0, 0, 1, -1 };
            // input
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = input[0];
            int m = input[1];
            int[,] table = new int[n + 2, m + 2];
            int[,] count = new int[n + 2, m + 2];
            bool[,] visited = new bool[n + 2, m + 2];
            int cheese = 0;
            for (int i = 1; i <= n; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                {
                    for (int j = 1; j <= m; j++)
                    {
                        table[i, j] = input[j - 1];
                        if (table[i, j] == 1)
                            cheese++;
                    }
                }
            }
            int time = 0;
            var q = new Queue<(int, int)>();
            while (cheese > 0)
            {
                time++;
                visited = new bool[n + 2, m + 2];
                count = new int[n + 2, m + 2];
                // bfs
                q.Enqueue((1, 1));
                while (q.Count > 0)
                {
                    var item = q.Dequeue();
                    int y = item.Item1;
                    int x = item.Item2;

                    if (x > m || x < 1 || y > n || y < 1)
                        continue;

                    for (int i = 0; i < 4; i++)
                    {
                        if (table[y + dirY[i], x + dirX[i]] == 0)
                        {
                            if (visited[y + dirY[i], x + dirX[i]] == false)
                            {
                                q.Enqueue((y + dirY[i], x + dirX[i]));
                                visited[y + dirY[i], x + dirX[i]] = true;
                            }
                        }
                        else
                            count[y + dirY[i], x + dirX[i]]++;
                    }
                }

                // delete cheese
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= m; j++)
                    {
                        if (count[i, j] >= 2)
                        {
                            table[i, j] = 0;
                            cheese--;
                        }
                    }
                }
            }
            Console.WriteLine(time);
        }
    }
}
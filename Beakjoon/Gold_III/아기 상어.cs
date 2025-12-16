using System.ComponentModel.Design.Serialization;
using System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // init
            int[] dirY = { -1, 0, 0, 1 };
            int[] dirX = { 0, -1, 1, 0 };
            int exp = 0;
            int size = 2;
            int time = 0;
            int n = int.Parse(Console.ReadLine());
            int[,] table = new int[n + 2, n + 2];
            bool[,] visited = new bool[n + 2, n + 2];
            int startY = 0;
            int startX = 0;
            for (int i = 1; i <= n; i++)
            {
                int[] temp = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                for (int j = 1; j <= n; j++)
                {
                    table[i, j] = temp[j - 1];
                    if (table[i, j] == 9)
                    {
                        startY = i;
                        startX = j;
                    }
                }
            }
            table[startY, startX] = 0;
            var bfs = new Queue<(int, int, int)>(); // y, x, cost
            bfs.Enqueue((startY, startX, 0));
            int dist = int.MaxValue;
            List<(int, int)> pos = new List<(int, int)>();
            while (true)
            {
                while (bfs.Count > 0)
                {
                    var item = bfs.Dequeue();
                    int y = item.Item1;
                    int x = item.Item2;
                    int cost = item.Item3;
                    if (y > n || y < 1 || x > n || x < 1 || cost >= dist)
                        continue;

                    for (int i = 0; i < 4; i++)
                    {
                        int nextY = y + dirY[i];
                        int nextX = x + dirX[i];
                        if (table[nextY, nextX] == 0 || table[nextY, nextX] == size)
                        {
                            if (!visited[nextY, nextX])
                            {
                                bfs.Enqueue((nextY, nextX, cost + 1));
                                visited[nextY, nextX] = true;
                            }
                        }
                        else if (table[nextY, nextX] < size)
                        {
                            pos.Add((nextY, nextX));
                            dist = cost + 1;
                        }
                    }
                }
                if (pos.Count <= 0)
                    break;
                else
                {
                    pos.Sort((left, right) =>
                    {
                        if (left.Item1.CompareTo(right.Item1) == 0)
                            return left.Item2.CompareTo(right.Item2);
                        else
                            return left.Item1.CompareTo(right.Item1);
                    });
                    int ny = pos[0].Item1;
                    int nx = pos[0].Item2;
                    table[ny, nx] = 0;
                    time += dist;
                    exp++;
                    if (exp >= size)
                    {
                        size++;
                        exp = 0;
                    }
                    bfs.Clear();
                    bfs.Enqueue((ny, nx, 0));
                    pos.Clear();
                    dist = int.MaxValue;
                    visited = new bool[n + 2, n + 2];
                }
            }
            Console.WriteLine(time);
        }
    }
}
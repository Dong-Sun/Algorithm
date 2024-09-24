using System.Data.SqlTypes;
using System.Text;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] screen = new char[n + 2, n + 2];
            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 1; j <= n; j++)
                    screen[i, j] = input[j - 1];
            }
            bool[,] visited = new bool[n + 2, n + 2];
            Queue<(int, int)> q = new Queue<(int, int)>();
            int count = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (!visited[i, j])
                    {
                        char color = screen[i, j];
                        q.Enqueue((i, j));
                        count++;
                        while (q.Count > 0)
                        {
                            (int, int) cur = q.Dequeue();
                            int y = cur.Item1;
                            int x = cur.Item2;
                            if (y > n || y <= 0)
                                continue;
                            if (x > n || x <= 0)
                                continue;
                            if (screen[y, x] != color)
                                continue;
                            if (visited[y, x])
                                continue;
                            visited[y, x] = true;
                            q.Enqueue((y + 1, x));
                            q.Enqueue((y - 1, x));
                            q.Enqueue((y, x + 1));
                            q.Enqueue((y, x - 1));
                        }
                    }
                }
            }
            Console.Write($"{count} ");
            visited = new bool[n + 2, n + 2];
            q = new Queue<(int, int)>();
            count = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (!visited[i, j])
                    {
                        char color = screen[i, j];
                        q.Enqueue((i, j));
                        count++;
                        while (q.Count > 0)
                        {
                            (int, int) cur = q.Dequeue();
                            int y = cur.Item1;
                            int x = cur.Item2;
                            if (y > n || y <= 0)
                                continue;
                            if (x > n || x <= 0)
                                continue;
                            if (screen[y, x] != color)
                            {
                                if (!((color == 'R' && screen[y, x] == 'G') || (color == 'G' && screen[y, x] == 'R')))
                                    continue;
                            }
                            if (visited[y, x])
                                continue;
                            visited[y, x] = true;
                            q.Enqueue((y + 1, x));
                            q.Enqueue((y - 1, x));
                            q.Enqueue((y, x + 1));
                            q.Enqueue((y, x - 1));
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
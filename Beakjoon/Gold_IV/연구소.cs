namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            int blank = -3;
            int result = 0;
            Queue<(int, int)> q = new Queue<(int, int)>();
            string[] split = Console.ReadLine().Split(' ');
            n = int.Parse(split[0]);
            m = int.Parse(split[1]);
            List<(int, int)> pos = new List<(int, int)>();
            int[,] map = new int[n + 2, m + 2];
            for (int i = 1; i <= n; i++)
            {
                split = Console.ReadLine().Split(' ');
                for (int j = 1; j <= m; j++)
                {
                    map[i, j] = int.Parse(split[j - 1]);
                    if (map[i, j] == 0)
                        blank++;
                    else if (map[i, j] == 2)
                    {
                        blank++;
                        pos.Add((i, j));
                    }
                }
            }
            int temp = blank;
            for (int i = 0; i < n * m - 2; i++)
            {
                if (map[i / m + 1, i % m + 1] != 0)
                    continue;
                for (int j = i + 1; j < n * m - 1; j++)
                {
                    if (map[j / m + 1, j % m + 1] != 0)
                        continue;
                    for (int k = j + 1; k < n * m; k++)
                    {
                        if (map[k / m + 1, k % m + 1] != 0)
                            continue;
                        bool[,] visited = new bool[n + 2, m + 2];
                        blank = temp;
                        visited[i / m + 1, i % m + 1] = true;
                        visited[j / m + 1, j % m + 1] = true;
                        visited[k / m + 1, k % m + 1] = true;

                        q.Clear();
                        foreach (var v in pos)
                            q.Enqueue(v);

                        while (q.Count > 0)
                        {
                            (int, int) cur = q.Dequeue();
                            int y = cur.Item1;
                            int x = cur.Item2;

                            if (visited[y, x])
                                continue;

                            visited[y, x] = true;
                            blank--;
                            if (!visited[y + 1, x] && map[y + 1, x] == 0 && y + 1 <= n)
                            {
                                q.Enqueue((y + 1, x));
                            }
                            if (!visited[y - 1, x] && map[y - 1, x] == 0 && y - 1 > 0)
                            {
                                q.Enqueue((y - 1, x));
                            }
                            if (!visited[y, x + 1] && map[y, x + 1] == 0 && x + 1 <= m)
                            {
                                q.Enqueue((y, x + 1));
                            }
                            if (!visited[y, x - 1] && map[y, x - 1] == 0 && x - 1 > 0)
                            {
                                q.Enqueue((y, x - 1));
                            }
                        }
                        result = Math.Max(result, blank);
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
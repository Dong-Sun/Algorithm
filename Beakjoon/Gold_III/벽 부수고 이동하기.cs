namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = input[0];
            int m = input[1];
            int[,] map = new int[n + 2, m + 2];

            string str;
            for (int i = 1; i <= n; i++)
            {
                str = Console.ReadLine();
                for (int j = 1; j <= m; j++)
                {
                    if (str[j - 1].Equals('0'))
                        map[i, j] = 0;
                    else
                        map[i, j] = 1;
                }
            }

            bool[,,] visited = new bool[n + 2, m + 2, 2];
            var q = new Queue<(int, int, int, int)>();
            q.Enqueue((1, 1, 1, 1));
            visited[1, 1, 0] = true;
            bool finish = false;
            while (q.Count > 0)
            {
                var cur = q.Dequeue();
                int y = cur.Item1;
                int x = cur.Item2;
                int dist = cur.Item3;
                int able = cur.Item4;
                if (y == n && x == m)
                {
                    Console.WriteLine(dist);
                    finish = true;
                    break;
                }
                if (able == 1)
                {
                    if (x < m)
                    {
                        if (map[y, x + 1] == 0)
                        {
                            if (visited[y, x + 1, 0] == false)
                            {
                                q.Enqueue((y, x + 1, dist + 1, able));
                                visited[y, x + 1, 0] = true;
                            }
                        }
                        else if (visited[y, x + 1, 1] == false)
                        {
                            q.Enqueue((y, x + 1, dist + 1, 0));
                            visited[y, x + 1, 1] = true;
                        }
                    }
                    if (x > 1)
                    {
                        if (map[y, x - 1] == 0)
                        {
                            if (visited[y, x - 1, 0] == false)
                            {
                                q.Enqueue((y, x - 1, dist + 1, able));
                                visited[y, x - 1, 0] = true;
                            }
                        }
                        else if (visited[y, x - 1, 1] == false)
                        {
                            q.Enqueue((y, x - 1, dist + 1, 0));
                            visited[y, x - 1, 1] = true;
                        }
                    }
                    if (y < n)
                    {
                        if (map[y + 1, x] == 0)
                        {
                            if (visited[y + 1, x, 0] == false)
                            {
                                q.Enqueue((y + 1, x, dist + 1, able));
                                visited[y + 1, x, 0] = true;
                            }
                        }
                        else if (visited[y + 1, x, 1] == false)
                        {
                            q.Enqueue((y + 1, x, dist + 1, 0));
                            visited[y + 1, x, 1] = true;
                        }
                    }
                    if (y > 1)
                    {
                        if (map[y - 1, x] == 0)
                        {
                            if (visited[y - 1, x, 0] == false)
                            {
                                q.Enqueue((y - 1, x, dist + 1, able));
                                visited[y - 1, x, 0] = true;
                            }
                        }
                        else if (visited[y - 1, x, 1] == false)
                        {
                            q.Enqueue((y - 1, x, dist + 1, 0));
                            visited[y - 1, x, 1] = true;
                        }
                    }
                }
                else
                {
                    if (x < m)
                    {
                        if (map[y, x + 1] == 0)
                        {
                            if (visited[y, x + 1, 1] == false)
                            {
                                q.Enqueue((y, x + 1, dist + 1, able));
                                visited[y, x + 1, 1] = true;
                            }
                        }
                    }
                    if (x > 1)
                    {
                        if (map[y, x - 1] == 0)
                        {
                            if (visited[y, x - 1, 1] == false)
                            {
                                q.Enqueue((y, x - 1, dist + 1, able));
                                visited[y, x - 1, 1] = true;
                            }
                        }
                    }
                    if (y < n)
                    {
                        if (map[y + 1, x] == 0)
                        {
                            if (visited[y + 1, x, 1] == false)
                            {
                                q.Enqueue((y + 1, x, dist + 1, able));
                                visited[y + 1, x, 1] = true;
                            }
                        }
                    }
                    if (y > 1)
                    {
                        if (map[y - 1, x] == 0)
                        {
                            if (visited[y - 1, x, 1] == false)
                            {
                                q.Enqueue((y - 1, x, dist + 1, able));
                                visited[y - 1, x, 1] = true;
                            }
                        }
                    }
                }
            }

            if (finish == false)
                Console.WriteLine("-1");
        }
    }
}
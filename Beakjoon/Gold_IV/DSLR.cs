namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t > 0)
            {
                t--;
                string[] split = Console.ReadLine().Split();
                short start = short.Parse(split[0]);
                short end = short.Parse(split[1]);
                Queue<(short, string)> q = new Queue<(short, string)>();
                bool[] visited = new bool[10000];
                q.Enqueue((start, ""));
                while (q.Count > 0)
                {
                    (short, string) temp = q.Dequeue();
                    short cur = temp.Item1;
                    string result = temp.Item2;
                    if (cur == end)
                    {
                        Console.WriteLine(result);
                        break;
                    }
                    (short, string) next = Left(cur, result);
                    if (!visited[next.Item1])
                    {
                        visited[next.Item1] = true;
                        q.Enqueue(next);
                    }
                    next = Right(cur, result);
                    if (!visited[next.Item1])
                    {
                        visited[next.Item1] = true;
                        q.Enqueue(next);
                    }
                    next = Double(cur, result);
                    if (!visited[next.Item1])
                    {
                        visited[next.Item1] = true;
                        q.Enqueue(next);
                    }
                    next = Subtract(cur, result);
                    if (!visited[next.Item1])
                    {
                        visited[next.Item1] = true;
                        q.Enqueue(next);
                    }
                }
            }
        }
        static (short, string) Left(short n, string str)
        {
            short temp = (short)(n % 1000 * 10 + n / 1000);
            return (temp, str + 'L');
        }
        static (short, string) Right(short n, string str)
        {
            short temp = (short)(n / 10 + n % 10 * 1000);
            return (temp, str + 'R');
        }
        static (short, string) Double(short n, string str)
        {
            short temp = (short)(n * 2 % 10000);
            return (temp, str + 'D');
        }
        static (short, string) Subtract(short n, string str)
        {
            short temp = (short)(n != 0 ? n - 1 : 9999);
            return (temp, str + 'S');
        }
    }
}
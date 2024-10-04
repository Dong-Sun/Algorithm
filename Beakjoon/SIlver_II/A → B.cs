namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] split = Console.ReadLine().Split(' ');
            long a = int.Parse(split[0]);
            long b = int.Parse(split[1]);
            bool[] visited = new bool[b + 1];
            Queue<(long, int)> bfs = new Queue<(long, int)>();
            bfs.Enqueue((a, 1));
            visited[a] = true;
            int result = 0;
            while (bfs.Count > 0)
            {
                (long, int) n = bfs.Dequeue();
                if (n.Item1 == b)
                {
                    result = n.Item2;
                    break;
                }
                if (n.Item1 * 2 <= b && !visited[n.Item1 * 2])
                {
                    bfs.Enqueue((n.Item1 * 2, n.Item2 + 1));
                    visited[n.Item1 * 2] = true;
                }
                if (n.Item1 * 10 + 1 <= b && !visited[n.Item1 * 10 + 1])
                {
                    bfs.Enqueue((n.Item1 * 10 + 1, n.Item2 + 1));
                    visited[n.Item1 * 10 + 1] = true;
                }
            }
            if (result != 0)
                Console.WriteLine(result);
            else
                Console.WriteLine("-1");
        }
    }
}
namespace Debug
{
    class Program
    {
        static Func<int[]> InputIntArray = () => Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        static Func<int> InputInt = () => int.Parse(Console.ReadLine());
        static void Main(string[] args)
        {
            int n = InputInt.Invoke();
            int[,] table = new int[n + 2, n + 2];
            for (int i = 1; i <= n; i++)
            {
                int[] temp = InputIntArray.Invoke();
                for (int j = 1; j <= n; j++)
                    table[i, j] = temp[j - 1];
            }
            int[,] dp = new int[n + 2, n + 2];
            // dir 0 = 오른쪽, 1 = 대각, 2 = 아레
            //      y    x      dir
            Queue<((int, int), int)> bfs = new Queue<((int, int), int)>();
            bfs.Enqueue(((1, 2), 0));
            while (bfs.Count > 0)
            {
                ((int, int), int) cur = bfs.Dequeue();
                (int, int) pos = cur.Item1;
                int dir = cur.Item2;
                int y = pos.Item1;
                int x = pos.Item2;
                if (y > n || y <= 0)
                    continue;
                if (x > n || x <= 0)
                    continue;
                dp[y, x]++;
                if (table[y, x + 1] != 1 && table[y + 1, x] != 1 && table[y + 1, x + 1] != 1)
                    bfs.Enqueue(((y + 1, x + 1), 1));
                if (dir != 0 && table[y + 1, x] != 1)
                    bfs.Enqueue(((y + 1, x), 2));
                if (dir != 2 && table[y, x + 1] != 1)
                    bfs.Enqueue(((y, x + 1), 0));
            }
            Console.WriteLine(dp[n, n]);
        }
    }
}
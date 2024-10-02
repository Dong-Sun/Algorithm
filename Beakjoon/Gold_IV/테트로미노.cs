namespace Solution
{
    class Program
    {
        static int n = 0;
        static int m = 0;
        static int[,] table;
        static int result = 0;
        static void Main(string[] args)
        {
            // input
            string[] split = Console.ReadLine().Split();
            n = int.Parse(split[0]);
            m = int.Parse(split[1]);
            table = new int[n + 2, m + 2];
            for (int i = 1; i <= n; i++)
            {
                split = Console.ReadLine().Split();
                for (int j = 1; j <= m; j++)
                {
                    table[i, j] = int.Parse(split[j - 1]);
                }
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    Dfs(i, j, i, j, 1, 0);
                }
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int sum = table[i, j] + table[i + 1, j] + table[i - 1, j] + table[i, j + 1] + table[i, j - 1];
                    result = result >= sum - table[i + 1, j] ? result : sum - table[i + 1, j];
                    result = result >= sum - table[i - 1, j] ? result : sum - table[i - 1, j];
                    result = result >= sum - table[i, j + 1] ? result : sum - table[i, j + 1];
                    result = result >= sum - table[i, j - 1] ? result : sum - table[i, j - 1];
                }
            }
            Console.WriteLine(result);
        }
        static void Dfs(int y, int x, int prevY, int prevX, int depth, int sum)
        {
            if (y <= 0 || y > n)
            {
                return;
            }
            if (x <= 0 || x > m)
            {
                return;
            }
            if (depth == 4)
            {
                result = result >= sum + table[y, x] ? result : sum + table[y, x];
                return;
            }
            if (!(y + 1 == prevY && x == prevX))
                Dfs(y + 1, x, y, x, depth + 1, sum + table[y, x]);
            if (!(y - 1 == prevY && x == prevX))
                Dfs(y - 1, x, y, x, depth + 1, sum + table[y, x]);
            if (!(y == prevY && x + 1 == prevX))
                Dfs(y, x + 1, y, x, depth + 1, sum + table[y, x]);
            if (!(y == prevY && x - 1 == prevX))
                Dfs(y, x - 1, y, x, depth + 1, sum + table[y, x]);
        }
    }
}
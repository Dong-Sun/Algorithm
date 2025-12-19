namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] split = Console.ReadLine().Split();
            int n = int.Parse(split[0]);
            int m = int.Parse(split[1]);
            int[,] dp = new int[n + 1, 10005];
            split = Console.ReadLine().Split();
            int[] memories = new int[n + 1];
            for (int i = 1; i <= n; i++)
                memories[i] = int.Parse(split[i - 1]);

            split = Console.ReadLine().Split();
            int[] costs = new int[n + 1];
            for (int i = 1; i <= n; i++)
                costs[i] = int.Parse(split[i - 1]);

            // (i, cost) 비용순으로 앱 정렬
            PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();

            for (int i = 1; i <= n; i++)
                pq.Enqueue((i, costs[i]), costs[i]);

            for (int i = 1; i <= n; i++)
            {
                var item = pq.Dequeue();
                int index = item.Item1;
                int cost = item.Item2;
                for (int j = 0; j < cost; j++)
                {
                    dp[i, j] = dp[i - 1, j];
                }
                for (int j = cost; j < 10005; j++)
                {
                    dp[i, j] = Math.Max(dp[i - 1, j - cost] + memories[index], dp[i - 1, j]);
                }
            }
            for (int i = 0; i < 10005; i++)
            {
                if (dp[n, i] >= m)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}
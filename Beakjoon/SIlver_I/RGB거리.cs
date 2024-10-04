namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] cost = new int[3];
            int[,] house = new int[n + 1, 3];
            for (int i = 1; i <= n; i++)
            {
                string[] split = Console.ReadLine().Split();
                cost[0] = int.Parse(split[0]);
                cost[1] = int.Parse(split[1]);
                cost[2] = int.Parse(split[2]);
                house[i, 0] = Math.Min(house[i - 1, 1], house[i - 1, 2]) + cost[0];
                house[i, 1] = Math.Min(house[i - 1, 0], house[i - 1, 2]) + cost[1];
                house[i, 2] = Math.Min(house[i - 1, 0], house[i - 1, 1]) + cost[2];
            }
            Console.WriteLine(Math.Min(Math.Min(house[n, 0], house[n, 1]), house[n, 2]));
        }
    }
}
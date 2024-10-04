namespace Solution
{
    class Program
    {
        static int[] arr;
        static void Main(string[] args)
        {
            string[] split = Console.ReadLine().Split();
            int n = int.Parse(split[0]);
            int m = int.Parse(split[1]);
            arr = new int[m];
            Dfs(0, m, n, 1);
        }
        static void Dfs(int depth, int m, int n, int index)
        {
            if (depth == m)
            {
                foreach (int num in arr)
                    Console.Write($"{num} ");
                Console.WriteLine();
                return;
            }
            for (int i = index; i <= n; i++)
            {
                arr[depth] = i;
                Dfs(depth + 1, m, n, i);
            }
        }
    }
}
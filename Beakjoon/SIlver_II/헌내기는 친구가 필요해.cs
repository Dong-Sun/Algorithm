namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution();
        }

        public static void Solution()
        {
            string[] split = Console.ReadLine().Split();
            int n = int.Parse(split[0]);
            int m = int.Parse(split[1]);
            char[,] campus = new char[n + 2, m + 2];
            bool[,] visited = new bool[n + 2, m + 2];
            Queue<(int, int)> q = new Queue<(int, int)>();
            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                {
                    campus[i, j + 1] = input[j];
                    if (input[j] == 'I')
                        q.Enqueue((i, j + 1));
                }
            }
            int count = 0;
            while (q.Count > 0)
            {
                (int, int) v = q.Dequeue();
                if (visited[v.Item1, v.Item2] == true)
                    continue;
                else
                    visited[v.Item1, v.Item2] = true;
                if (campus[v.Item1, v.Item2] == 'P')
                    count++;
                else if (campus[v.Item1, v.Item2] != 'O' && campus[v.Item1, v.Item2] != 'I')
                    continue;

                q.Enqueue((v.Item1 + 1, v.Item2));
                q.Enqueue((v.Item1 - 1, v.Item2));
                q.Enqueue((v.Item1, v.Item2 + 1));
                q.Enqueue((v.Item1, v.Item2 - 1));
            }
            if (count > 0)
                Console.WriteLine(count);
            else
                Console.WriteLine("TT");
        }
    }
}
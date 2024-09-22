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
            int n = int.Parse(Console.ReadLine());
            char[,] table = new char[n + 2, n + 2];
            bool[,] visited = new bool[n + 2, n + 2];
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < n; j++)
                    table[i + 1, j + 1] = input[j];
            }
            Queue<(int, int)> bfs = new Queue<(int, int)>();
            int house; // 단지내 집의 수
            List<int> arr = new List<int>(); // 집의 수 배열
            int count = 0; // 단지 수
            for (int y = 1; y <= n; y++)
            {
                for (int x = 1; x <= n; x++)
                {
                    if (table[y, x].Equals('0') || visited[y, x])
                        continue;
                    bfs.Enqueue((y, x));
                    house = 0;
                    count++;
                    while (bfs.Count > 0)
                    {
                        (int, int) cur = bfs.Dequeue();
                        int ypos = cur.Item1;
                        int xpos = cur.Item2;
                        if (table[ypos, xpos].Equals('0') || visited[ypos, xpos])
                            continue;
                        if (ypos > n || ypos <= 0)
                            continue;
                        if (xpos > n || xpos <= 0)
                            continue;
                        visited[ypos, xpos] = true;
                        house++;
                        bfs.Enqueue((ypos + 1, xpos));
                        bfs.Enqueue((ypos - 1, xpos));
                        bfs.Enqueue((ypos, xpos + 1));
                        bfs.Enqueue((ypos, xpos - 1));
                    }
                    arr.Add(house);
                }
            }
            arr.Sort();
            Console.WriteLine(count);
            foreach (int num in arr)
                Console.WriteLine(num);
        }
    }
}
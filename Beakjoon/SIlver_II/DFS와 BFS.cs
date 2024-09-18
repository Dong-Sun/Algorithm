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
            int v = int.Parse(split[2]);
            List<List<int>> Vertex = new List<List<int>>(n + 1);
            for (int i = 0; i <= n; i++)
                Vertex.Add(new List<int>(n + 1));

            // 간선 연결
            for (int i = 0; i < m; i++)
            {
                split = Console.ReadLine().Split();
                int left = int.Parse(split[0]);
                int right = int.Parse(split[1]);
                Vertex[left].Add(right);
                Vertex[right].Add(left);
            }

            //dfs
            foreach (List<int> list in Vertex)
            {
                list.Sort();
                list.Reverse();
            }

            bool[] visited = new bool[n + 1];
            Stack<int> dfs = new Stack<int>();
            dfs.Push(v);
            while (dfs.Count > 0)
            {
                int cur = dfs.Pop();
                if (visited[cur] == true)
                    continue;
                else
                    visited[cur] = true;
                Console.Write(cur + " ");
                foreach (int next in Vertex[cur])
                {
                    if (visited[next] == false)
                    {
                        dfs.Push(next);
                    }
                }
            }
            Console.WriteLine();
            // bfs
            foreach (List<int> list in Vertex)
                list.Reverse();
            visited = new bool[n + 1];
            Queue<int> bfs = new Queue<int>();
            bfs.Enqueue(v);
            while (bfs.Count > 0)
            {
                int cur = bfs.Dequeue();
                if (visited[cur] == true)
                    continue;
                else
                    visited[cur] = true;
                Console.Write(cur + " ");
                foreach (int next in Vertex[cur])
                {
                    if (visited[next] == false)
                    {
                        bfs.Enqueue(next);
                    }
                }
            }
        }
    }
}
using System.Text;

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
            StringBuilder sb = new StringBuilder();
            string[] split = Console.ReadLine().Split();
            int n = int.Parse(split[0]); // 정점 수
            int m = int.Parse(split[1]); // 간선 수
            bool[] visited = new bool[n + 1];
            List<List<int>> vertex = new List<List<int>>(n + 1);
            for (int i = 0; i < n + 1; i++)
                vertex.Add(new List<int>(n + 1));
            for (int i = 0; i < m; i++)
            {
                split = Console.ReadLine().Split();
                int left = int.Parse(split[0]);
                int right = int.Parse(split[1]);
                vertex[left].Add(right);
                vertex[right].Add(left);
            }
            int result = 0;
            for (int i = 1; i < vertex.Count; i++)
            {
                if (visited[i] == true)
                    continue;
                Queue<int> bfs = new Queue<int>();
                bfs.Enqueue(i);
                while (bfs.Count > 0)
                {
                    int cur = bfs.Dequeue();
                    if (visited[cur] == true)
                        continue;
                    else
                        visited[cur] = true;
                    foreach (int num in vertex[cur])
                        if (visited[num] == false)
                            bfs.Enqueue(num);
                }
                result++;
            }
            Console.WriteLine(result);
        }
    }
}
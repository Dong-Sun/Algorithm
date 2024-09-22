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
            int n = int.Parse(Console.ReadLine());
            int[,] table = new int[n, n];
            List<List<int>> vertex = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                vertex.Add(new List<int>());
                string[] split = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    table[i, j] = int.Parse(split[j]);
                    if (table[i, j] == 1)
                        vertex[i].Add(j);
                }
            }
            for (int start = 0; start < n; start++)
            {
                bool[] visited = new bool[n];
                Queue<int> q = new Queue<int>();
                q.Enqueue(start);
                while (q.Count > 0)
                {
                    int cur = q.Dequeue();
                    if (visited[cur])
                        continue;
                    visited[cur] = true;
                    foreach (int num in vertex[cur])
                    {
                        q.Enqueue(num);
                        table[start, num] = 1;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    sb.Append(table[i, j] + " ");
                sb.Append("\n");
            }
            Console.Write(sb.ToString());
        }
    }
}
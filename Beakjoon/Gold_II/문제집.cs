using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new();
        static int n;
        static int m;
        static int[] indegree;
        static List<List<int>> parent;
        static bool[] visited;
        static void Main(string[] args)
        {
            // 입력
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            n = input[0];
            m = input[1];
            indegree = new int[n + 1];
            parent = new();
            visited = new bool[n + 1];
            for (int i = 0; i <= n; i++)
                parent.Add(new List<int>());
            while (m-- > 0)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                parent[input[0]].Add(input[1]);
                indegree[input[1]]++;
            }

            // 구현
            PriorityQueue<int, int> pq = new();
            for (int i = 1; i <= n; i++)
            {
                if (indegree[i] == 0)
                {
                    pq.Enqueue(i, i);
                    visited[i] = true;
                }
            }
            while (pq.Count > 0)
            {
                var cur = pq.Dequeue();
                sb.Append(cur + " ");
                foreach (var v in parent[cur])
                {
                    indegree[v]--;
                    if (indegree[v] <= 0)
                    {
                        pq.Enqueue(v, v);
                        visited[v] = true;
                    }
                }
            }

            // 출력
            System.Console.WriteLine(sb);
        }
    }
}
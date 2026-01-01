using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = input[0];   // 학생 수
            int m = input[1];   // 키를 비교한 횟수
            int[] inDegree = new int[n + 1];    // 진입차수
            List<List<int>> edges = new List<List<int>>(n + 1); // 간선
            for (int i = 0; i <= n; i++)
                edges.Add(new List<int>());
            Queue<int> q = new Queue<int>();
            while (m-- > 0)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int a = input[0];
                int b = input[1];
                edges[a].Add(b);
                inDegree[b]++;
            }
            for (int i = 1; i <= n; i++)
                if (inDegree[i] == 0)
                    q.Enqueue(i);
            for (int i = 1; i <= n; i++)
            {
                int cur = q.Dequeue();
                sb.Append(cur + " ");
                foreach (var v in edges[cur])
                {
                    if (--inDegree[v] == 0)
                        q.Enqueue(v);
                }
            }
            Console.WriteLine(sb);
        }
    }
}
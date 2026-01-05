using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = input[0];
            int m = input[1];
            int start;
            int end;
            int[] inDegree = new int[n + 1];
            List<int>[] edges = new List<int>[n + 1];
            for (int i = 0; i <= n; i++)
                edges[i] = new List<int>();
            while (m-- > 0)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                for (int i = 1; i < input[0]; i++)
                {
                    start = input[i];
                    end = input[i + 1];
                    edges[start].Add(end);
                    inDegree[end]++;
                }
            }
            var q = new Queue<int>();
            for (int i = 1; i <= n; i++)
            {
                if (inDegree[i] == 0)
                {
                    q.Enqueue(i);
                    sb.AppendLine(i.ToString());
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (q.Count <= 0)
                {
                    Console.WriteLine("0");
                    return;
                }
                int cur = q.Dequeue();
                foreach (var v in edges[cur])
                {
                    inDegree[v]--;
                    if (inDegree[v] == 0)
                    {
                        q.Enqueue(v);
                        sb.AppendLine(v.ToString());
                    }
                }
            }
            Console.WriteLine(sb);
        }
    }
}
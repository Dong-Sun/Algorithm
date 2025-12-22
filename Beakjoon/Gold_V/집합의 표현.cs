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
            int[] parent = new int[n + 1];
            int[] rank = new int[n + 1];
            Queue<int> q = new Queue<int>();
            for (int i = 0; i <= n; i++)
                parent[i] = i;
            while (m-- > 0)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int request = input[0];
                int a = input[1];
                int b = input[2];
                int rootA = a;
                int rootB = b;

                while (rootA != parent[rootA])
                {
                    q.Enqueue(rootA);
                    rootA = parent[rootA];
                }
                while (q.Count > 0)
                    parent[q.Dequeue()] = rootA;

                while (rootB != parent[rootB])
                {
                    q.Enqueue(rootB);
                    rootB = parent[rootB];
                }
                while (q.Count > 0)
                    parent[q.Dequeue()] = rootB;

                if (request == 0)
                {
                    if (rootA != rootB)
                    {
                        if (rank[rootA] == rank[rootB])
                        {
                            parent[rootB] = rootA;
                            rank[rootA]++;
                        }
                        else if (rank[rootA] > rank[rootB])
                            parent[rootB] = rootA;
                        else
                            parent[rootA] = rootB;
                    }
                }
                else
                {
                    if (parent[a] == parent[b])
                        sb.AppendLine("YES");
                    else
                        sb.AppendLine("NO");
                }
            }
            Console.WriteLine(sb);
        }
    }
}
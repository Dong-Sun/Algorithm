using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

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
            int k = int.Parse(split[1]);
            bool[] visited = new bool[100005];
            Queue<(int, int)> bfs = new Queue<(int, int)>();
            bfs.Enqueue((n, 0));
            while (bfs.Count > 0)
            {
                (int, int) cur = bfs.Dequeue();
                int pos = cur.Item1;
                int count = cur.Item2;
                if (pos == k)
                {
                    Console.WriteLine(count);
                    break;
                }
                if (visited[pos])
                    continue;
                visited[pos] = true;
                if (pos + 1 <= 100000)
                    bfs.Enqueue((pos + 1, count + 1));
                if (pos * 2 <= 100000)
                    bfs.Enqueue((pos * 2, count + 1));
                if (pos - 1 >= 0)
                    bfs.Enqueue((pos - 1, count + 1));
            }
        }
    }
}
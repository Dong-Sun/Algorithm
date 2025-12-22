namespace CSharp
{
    class Program
    {
        static int[] graph;
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int V = input[0];
            int E = input[1];
            int result = 0;
            graph = new int[V + 1];
            for (int i = 1; i <= V; i++)
                graph[i] = i;
            PriorityQueue<(int, int, int), int> edges = new PriorityQueue<(int, int, int), int>();
            while (E-- > 0)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                edges.Enqueue((input[0], input[1], input[2]), input[2]);
            }
            while (edges.Count > 0)
            {
                var item = edges.Dequeue();
                int a = item.Item1;
                int b = item.Item2;
                int cost = item.Item3;
                a = Find(a);
                b = Find(b);
                if (a == b) continue;
                graph[b] = a;
                result += cost;
            }
            Console.WriteLine(result);
        }
        static int Find(int n)
        {
            if (n != graph[n])
                graph[n] = Find(graph[n]);
            return graph[n];
        }
    }
}
namespace Debug
{
    class Program
    {
        static Func<int[]> InputIntArray = () => Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        static void Main(string[] args)
        {
            int[] input = InputIntArray();
            int n = input[0];
            int k = input[1];
            const int MAX = 100001;
            int[] distance = Enumerable.Repeat(100005, 100001).ToArray();
            bool[] visited = new bool[MAX];
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            pq.Enqueue(n, 0);
            distance[n] = 0;
            while (pq.Count > 0)
            {
                int cur = pq.Dequeue();
                int second = distance[cur];
                if (cur == k)
                {
                    Console.WriteLine(second);
                    break;
                }
                if (visited[cur])
                    continue;
                visited[cur] = true;
                if (cur * 2 < MAX && second < distance[cur * 2])
                {
                    distance[cur * 2] = second;
                    pq.Enqueue(cur * 2, second);
                }
                if (cur + 1 < MAX && second + 1 < distance[cur + 1])
                {
                    distance[cur + 1] = second + 1;
                    pq.Enqueue(cur + 1, second + 1);
                }
                if (cur - 1 >= 0 && second + 1 < distance[cur - 1])
                {
                    distance[cur - 1] = second + 1;
                    pq.Enqueue(cur - 1, second + 1);
                }
            }
        }
    }
}
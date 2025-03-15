namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            int start, end;
            int result = 100050;
            int count = 0;
            string[] input = Console.ReadLine().Split(' ');
            start = int.Parse(input[0]);
            end = int.Parse(input[1]);

            // (pos, time)
            Queue<(int, int)> q = new Queue<(int, int)>();
            q.Enqueue((start, 0));
            bool[] visited = new bool[100001];
            while (q.Count > 0)
            {
                (int, int) cur = q.Dequeue();
                int pos = cur.Item1;
                int time = cur.Item2;
                if (pos == end && time <= result) // 도착했을 때 최소 시간
                {
                    result = time;
                    count++;
                    continue;
                }
                visited[pos] = true;
                if (time < result)
                {
                    if (pos * 2 <= 100000)
                        if (!visited[pos * 2])
                            q.Enqueue((pos * 2, time + 1));
                    if (pos + 1 <= 100000)
                        if (!visited[pos + 1])
                            q.Enqueue((pos + 1, time + 1));
                    if (pos - 1 >= 0)
                        if (!visited[pos - 1])
                            q.Enqueue((pos - 1, time + 1));
                }
            }
            Console.Write($"{result}\n{count}");
        }
    }
}
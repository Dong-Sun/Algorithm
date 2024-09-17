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
            string input = Console.ReadLine();
            int n = int.Parse(input);
            input = Console.ReadLine();
            int m = int.Parse(input);
            List<List<int>> nodes = new List<List<int>>();
            for (int i = 0; i < n + 1; i++)
                nodes.Add(new List<int>());
            bool[] visited = new bool[n + 1];
            for (int i = 0; i < m; i++)
            {
                string[] split = Console.ReadLine().Split(' ');
                int left = int.Parse(split[0]);
                int right = int.Parse(split[1]);
                nodes[left].Add(right);
                nodes[right].Add(left);
            }
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            visited[1] = true;
            int count = 0;
            while (q.Count > 0)
            {
                int node = q.Dequeue();
                foreach (int num in nodes[node])
                {
                    if (visited[num] == false)
                    {
                        q.Enqueue(num);
                        visited[num] = true;
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
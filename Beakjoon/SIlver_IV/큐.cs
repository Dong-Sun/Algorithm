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
            Queue<int> q = new Queue<int>();
            int N = int.Parse(Console.ReadLine());
            while (N > 0)
            {
                string[] split = Console.ReadLine().Split(' ');
                if (split[0].Equals("push"))
                    q.Enqueue(int.Parse(split[1]));
                else if (split[0].Equals("front"))
                    sb.Append((q.Count == 0 ? -1 : q.Peek()) + "\n");
                else if (split[0].Equals("back"))
                    sb.Append((q.Count == 0 ? -1 : q.ElementAt(q.Count - 1)) + "\n");
                else if (split[0].Equals("size"))
                    sb.Append(q.Count + "\n");
                else if (split[0].Equals("pop"))
                    sb.Append((q.Count == 0 ? -1 : q.Dequeue()) + "\n");
                else if (split[0].Equals("empty"))
                    sb.Append((q.Count == 0 ? 1 : 0) + "\n");
                N--;
            }
            Console.Write(sb.ToString());
        }
    }
}
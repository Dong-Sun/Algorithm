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
            int n = int.Parse(Console.ReadLine());
            PriorityQueue<int, float> pq = new PriorityQueue<int, float>();
            while (n > 0)
            {
                int x = int.Parse(Console.ReadLine());
                if (x == 0)
                {
                    if (pq.Count <= 0)
                        sb.Append("0\n");
                    else
                        sb.Append(pq.Dequeue() + "\n");
                }
                else
                {
                    float priority = x;
                    if (priority < 0)
                        priority += 0.1f;
                    pq.Enqueue(x, Math.Abs(priority));
                }
                n--;
            }
            Console.Write(sb.ToString());
        }
    }
}
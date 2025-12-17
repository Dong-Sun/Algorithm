using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices.Marshalling;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // init
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int C = input[0];
            int N = input[1];
            int[] dp = new int[2000];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = 10000000;
            dp[0] = 0;
            PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>(N);  // value, cost
            while (N-- > 0)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                pq.Enqueue((input[0], input[1]), input[0]);
            }

            int min = int.MaxValue;
            while (pq.Count > 0)
            {
                var item = pq.Dequeue();
                int value = item.Item1;
                int cost = item.Item2;
                for (int i = 0; i < cost; i++)
                {
                    if (dp[i] > value) dp[i] = value;
                }
                for (int i = cost; i < 2000; i++)
                {
                    if (dp[i] > dp[i - cost] + value)
                        dp[i] = dp[i - cost] + value;
                }
            }
            Console.WriteLine(dp[C]);
        }
    }
}
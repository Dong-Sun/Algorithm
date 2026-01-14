using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new();
        static PriorityQueue<(int price, int day), int> pq = new();
        static int n;
        static int result = 0;
        static int[] prices = new int[10001];
        static void Main(string[] args)
        {
            // 입력
            n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                pq.Enqueue((input[0], input[1]), -input[0]);
            }

            // 구현
            while (pq.Count > 0)
            {
                var item = pq.Dequeue();
                int p = item.price;
                int d = item.day;
                for (int day = d; day > 0; day--)
                {
                    if (prices[day] < p)
                    {
                        prices[day] = p;
                        break;
                    }
                }
            }
            for (int i = 1; i < 10001; i++)
                result += prices[i];

            // 출력
            Console.WriteLine(result);
        }
    }
}
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
            int N = int.Parse(Console.ReadLine());
            string[] split1 = Console.ReadLine().Split();
            int M = int.Parse(Console.ReadLine());
            string[] split2 = Console.ReadLine().Split();
            StringBuilder sb = new StringBuilder();
            Dictionary<int, int> d = new Dictionary<int, int>(N);
            for (int i = 0; i < split1.Length; i++)
            {
                int num = int.Parse(split1[i]);
                if (d.ContainsKey(num))
                    d[num]++;
                else
                    d.Add(num, 1);
            }

            for (int i = 0; i < split2.Length; i++)
            {
                int num = int.Parse(split2[i]);
                if (d.ContainsKey(num))
                    sb.Append(d[num] + " ");
                else
                    sb.Append("0 ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
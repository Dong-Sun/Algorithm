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
            string[] split = Console.ReadLine().Split();
            StringBuilder sb = new StringBuilder();
            int n = int.Parse(split[0]);
            int m = int.Parse(split[1]);
            Dictionary<string, string> d = new Dictionary<string, string>(n);
            for (int i = 0; i < n; i++)
            {
                split = Console.ReadLine().Split();
                d.Add(split[0], split[1]);
            }
            for (int j = 0; j < m; j++)
            {
                sb.Append(d[Console.ReadLine()] + "\n");
            }
            Console.Write(sb);
        }
    }
}
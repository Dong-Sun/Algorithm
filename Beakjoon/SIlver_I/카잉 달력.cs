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
            int t = int.Parse(Console.ReadLine());
            while (t > 0)
            {
                string[] split = Console.ReadLine().Split();
                int m = int.Parse(split[0]);
                int n = int.Parse(split[1]);
                int x = int.Parse(split[2]);
                int y = int.Parse(split[3]);
                int a = m;
                int b = n;
                while (b != 0)
                {
                    int r = a % b;
                    a = b;
                    b = r;
                }
                int gcd = a;
                int lcm = m * n / gcd;
                int i;
                for (i = x; i <= lcm; i += m)
                {
                    int temp = i % n == 0 ? n : i % n;
                    if (temp == y)
                    {
                        sb.Append(i + "\n");
                        break;
                    }
                }
                if (i > lcm)
                    sb.Append("-1\n");
                t--;
            }
            Console.Write(sb.ToString());
        }
    }
}
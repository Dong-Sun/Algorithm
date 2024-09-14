using System.Text;

namespace SilverV
{
    class _11723
    {
        static void Main(string[] args)
        {
            Solution();
        }

        public static void Solution()
        {
            int m = int.Parse(Console.ReadLine());
            int num = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string op = input[0];
                if (op == "add")
                {
                    int x = int.Parse(input[1]);
                    num |= (1 << x);
                }
                else if (op == "remove")
                {
                    int x = int.Parse(input[1]);
                    num &= ~(1 << x);
                }
                else if (op == "check")
                {
                    int x = int.Parse(input[1]);
                    if ((num & (1 << x)) == 0)
                    {
                        sb.Append(0 + "\n");
                    }
                    else
                    {
                        sb.Append(1 + "\n");
                    }
                }
                else if (op == "toggle")
                {
                    int x = int.Parse(input[1]);
                    num ^= (1 << x);
                }
                else if (op == "all")
                {
                    num = (1 << 21) - 1;
                }
                else if (op == "empty")
                {
                    num = 0;
                }
            }
            Console.WriteLine(sb);
        }
    }
}
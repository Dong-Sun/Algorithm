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
            List<string> lists = new List<string>();
            string[] split = Console.ReadLine().Split();
            int n = int.Parse(split[0]);
            int m = int.Parse(split[1]);
            HashSet<string> NoListens = new HashSet<string>(n);
            HashSet<string> NoLooks = new HashSet<string>(m);
            for (int i = 0; i < n; i++)
                NoListens.Add(Console.ReadLine());
            for (int i = 0; i < m; i++)
                NoLooks.Add(Console.ReadLine());
            int count = 0;
            foreach (string str in NoListens)
            {
                if (NoLooks.Contains(str))
                {
                    count++;
                    lists.Add(str);
                }
            }
            lists.Sort();
            Console.WriteLine(count);
            foreach (string str in lists)
                Console.WriteLine(str);
        }
    }
}
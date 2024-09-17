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
            int T = int.Parse(Console.ReadLine());
            while (T > 0)
            {
                int n = int.Parse(Console.ReadLine());
                Dictionary<string, int> d = new Dictionary<string, int>();
                for (int i = 0; i < n; i++)
                {
                    string[] split = Console.ReadLine().Split();
                    if (d.ContainsKey(split[1]))
                        d[split[1]]++;
                    else
                        d.Add(split[1], 2);
                }
                int result = 1;
                foreach (var v in d)
                {
                    result *= v.Value;
                }
                result--;
                System.Console.WriteLine(result);
                T--;
            }
        }
    }
}
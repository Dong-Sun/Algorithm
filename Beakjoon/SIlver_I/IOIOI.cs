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
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int result = 0;
            for (int i = 0; i < m - 2; i++)
            {
                if (input[i].Equals('O'))
                    continue;
                int k = 0;
                while (input[i + 1].Equals('O') && input[i + 2].Equals('I'))
                {
                    k++;
                    if (k >= n)
                    {
                        k--;
                        result++;
                    }
                    i += 2;
                    if (i >= m - 2)
                        break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
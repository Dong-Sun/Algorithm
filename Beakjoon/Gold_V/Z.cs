namespace Algorithm
{
    class Program
    {
        static int r = 0;
        static int c = 0;
        static int count = 0;
        static bool isFind = false;
        static void Main(string[] args)
        {
            Solution();
        }

        public static void Solution()
        {
            string[] split = Console.ReadLine().Split();
            int n = int.Parse(split[0]);
            r = int.Parse(split[1]);
            c = int.Parse(split[2]);
            int S = (int)Math.Pow(2, n);
            Divide(0, 0, S);
        }
        static void Divide(int y, int x, int size)
        {
            if (c == x && r == y)
            {
                Console.WriteLine(count);
                return;
            }
            if (c < x + size && c >= x && r < y + size && r >= y)
            {
                Divide(y, x, size / 2);
                Divide(y, x + size / 2, size / 2);
                Divide(y + size / 2, x, size / 2);
                Divide(y + size / 2, x + size / 2, size / 2);
            }
            else
                count += size * size;
        }
    }
}
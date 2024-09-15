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
            int K = int.Parse(split[0]);
            ulong N = ulong.Parse(split[1]);
            ulong[] lans = new ulong[K];
            ulong start = 1;
            ulong end = 0;
            for (int i = 0; i < K; i++)
            {
                lans[i] = ulong.Parse(Console.ReadLine());
                end = lans[i] > end ? lans[i] : end;
            }
            end++;
            ulong pivot;
            while (start + 1 < end)
            {
                pivot = (start + end) / 2;
                ulong count = 0;
                foreach (ulong num in lans)
                {
                    count += num / pivot;
                }

                if (count >= N)
                    start = pivot;
                else
                    end = pivot;
            }
            Console.WriteLine(start);
        }
    }
}
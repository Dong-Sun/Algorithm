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
            string[] split = Console.ReadLine().Split();
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = int.Parse(split[i]);

            int[] fruits = new int[n + 1];
            int count = 0;
            int left = 0;
            int right = 1;
            if (n == 1)
            {
                Console.WriteLine("1");
                return;
            }

            fruits[arr[left]]++;
            count++;
            if (fruits[arr[right]] == 0)
                count++;
            fruits[arr[right]]++;

            int range = 0;
            while (true)
            {
                if (count < 3)
                {
                    range = (right - left + 1) > range ? right - left + 1 : range;
                    // right++, count check
                    right++;
                    if (right < n)
                    {
                        if (fruits[arr[right]] == 0)
                            count++;
                        fruits[arr[right]]++;
                    }
                    else
                        break;
                }
                else
                {
                    // left++, count check
                    fruits[arr[left]]--;
                    if (fruits[arr[left]] == 0)
                        count--;
                    left++;
                    if (left >= right)
                        break;
                }
            }
            System.Console.WriteLine(range);
        }
    }
}
namespace ConsoleApp1
{
    class Program
    {
        static void _4791() // 숫자구슬
        {
            string input = Console.ReadLine();
            int n = Convert.ToInt32(input.Split()[0]);
            int m = Convert.ToInt32(input.Split()[1]);

            int[] arr = new int[n];
            int left = 0;
            int right = 0;
            input = Console.ReadLine();
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(input.Split()[i]);
                right += arr[i];
                if (arr[i] > left)
                    left = arr[i];
            }

            int sum;
            int count;
            int mid = 0;
            while (left <= right)
            {
                sum = 0;
                count = 1;
                mid = (left + right) / 2;

                for (int i = 0; i < arr.Length; i++)
                {
                    sum += arr[i];
                    if (sum > mid)
                    {
                        count++;
                        sum = arr[i];
                    }
                }

                if (count > m)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            sum = 0;
            count = 0;
            Console.WriteLine($"{left}");
            for (int i = 0; i < n; i++)
            {
                sum += arr[i];
                if (sum > left)
                {
                    Console.Write($"{count} ");
                    m--;
                    sum = arr[i];
                    count = 0;
                }
                count++;
                if (n - i == m) break;
            }
            while (m > 0)
            {
                Console.Write($"{count} ");
                m--;
                count = 1;
            }
        }

        static void Main(string[] args)
        {
            _4791();
        }
    }
}
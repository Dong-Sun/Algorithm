namespace ConsoleApp1
{
    class Program
    {
        static void _1219() // 모자이크
        {
            string input;
            int col, row;
            input = Console.ReadLine();
            col = Convert.ToInt32(input.Split()[0]);
            row = Convert.ToInt32(input.Split()[1]);

            bool[] table = new bool[row + 1];
            int page = Convert.ToInt32(Console.ReadLine());
            int black = Convert.ToInt32(Console.ReadLine());

            int min = 0;
            int max = col;

            int left, right;

            for (int i = 0; i < black; i++)
            {
                input = Console.ReadLine();
                left = Convert.ToInt32(input.Split()[0]);
                right = Convert.ToInt32(input.Split()[1]);

                if (left >= min)
                    min = left;

                table[right] = true;
            }

            int mid = -1;
            int count = 0;
            bool find = false;
            while (min < max)
            {
                mid = (min + max) / 2;
                for (int i = 1; i <= row; i++)
                {
                    if (table[i])
                        find = true;

                    if (find)
                    {
                        i += mid - 1;
                        count++;
                        find = false;
                    }
                }
                if (count > page)
                    min = mid + 1;
                else
                    max = mid;
                count = 0;
            }
            Console.WriteLine($"{max}");
        }

        static void Main(string[] args)
        {
            _1219();
        }
    }
}

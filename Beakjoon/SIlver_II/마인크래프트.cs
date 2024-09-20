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
            string[] split = Console.ReadLine().Split();
            int n = int.Parse(split[0]); // 세로
            int m = int.Parse(split[1]); // 가로
            int b = int.Parse(split[2]); // 블록 수
            int[,] ground = new int[n, m];
            int max = 0;
            int min = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                split = Console.ReadLine().Split();
                for (int j = 0; j < split.Length; j++)
                {
                    ground[i, j] = int.Parse(split[j]);
                    max = ground[i, j] > max ? ground[i, j] : max;
                    min = ground[i, j] < min ? ground[i, j] : min;

                }
            }

            int resultTime = int.MaxValue;
            int resultHeight = 0;
            for (int height = max; height >= min; height--)
            {
                int time = 0;
                int block = b;
                for (int y = 0; y < n; y++)
                {
                    for (int x = 0; x < m; x++)
                    {
                        if (ground[y, x] > height)
                        {
                            block += ground[y, x] - height;
                            time += (ground[y, x] - height) * 2;
                        }
                        else if (ground[y, x] < height)
                        {
                            block -= height - ground[y, x];
                            time += height - ground[y, x];
                        }
                    }
                }
                if (block < 0)
                    continue;
                if (time < resultTime)
                {
                    resultTime = time;
                    resultHeight = height;
                }
            }
            Console.WriteLine($"{resultTime} {resultHeight}");
        }
    }
}
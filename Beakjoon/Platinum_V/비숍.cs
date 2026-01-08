using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
        static StreamReader sr = new StreamReader(Console.OpenStandardInput());
        static int[] input;
        static int n;   // 체스판의 크기
        static int[,] table;   // 체스판(놓을 수 있는 곳 : 1, 놓을 수 없는 곳 : 0)
        static int black;     // 어두운 비숍의 최대 개수
        static int white;     // 밝은 비숍의 최대 개수
        static void Main(string[] args)
        {
            // 크기 입력
            n = int.Parse(sr.ReadLine());
            // 체스판 입력
            table = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int j = 0; j < input.Length; j++)
                    table[i, j] = input[j];
            }
            // 탐색
            Dfs(0, 0, 0);
            Dfs(0, 0, 1);
            // 출력
            sw.WriteLine("{0}", white + black);
            sw.Flush();
        }
        static void Dfs(int depth, int y, int color)
        {
            if (color == 0)
                white = Math.Max(white, depth);
            else
                black = Math.Max(black, depth);
            for (int i = y; i < n; i++)
            {
                for (int j = (i + color) % 2; j < n; j += 2)
                {
                    if (table[i, j] <= 0) continue;
                    Oper(i, j, -1);
                    Dfs(depth + 1, i, color);
                    Oper(i, j, 1);
                }
            }
        }
        static void Oper(int y, int x, int op)
        {
            table[y, x] += op;
            int distance = 1;
            while (distance < n)
            {
                if (y + distance < n && x + distance < n)
                    table[y + distance, x + distance] += op;
                if (y - distance >= 0 && x + distance < n)
                    table[y - distance, x + distance] += op;
                if (y + distance < n && x - distance >= 0)
                    table[y + distance, x - distance] += op;
                if (y - distance >= 0 && x - distance >= 0)
                    table[y - distance, x - distance] += op;
                distance++;
            }
        }
    }
}
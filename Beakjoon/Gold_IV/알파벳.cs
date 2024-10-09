using System.Text;

namespace Debug
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static Func<int[]> InputIntArray = () => Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        static Func<int> InputInt = () => int.Parse(Console.ReadLine());
        static int r, c;
        static char[,] board;
        static bool[] alpha = new bool[27];
        static int result = 0;
        static void Main(string[] args)
        {
            int[] input = InputIntArray();
            r = input[0];
            c = input[1];
            board = new char[r + 2, c + 2];
            for (int i = 1; i <= r; i++)
            {
                string input2 = Console.ReadLine();
                for (int j = 1; j <= c; j++)
                    board[i, j] = input2[j - 1];
            }

            Dfs((1, 1), board[1, 1], 1);
            Console.WriteLine(result);
        }
        static void Dfs((int, int) pos, char a, int depth)
        {
            int row = pos.Item1;
            int col = pos.Item2;
            if (row > r || row <= 0)
                return;
            if (col > c || col <= 0)
                return;
            if (depth > result)
                result = depth;
            alpha[a - 64] = true;
            if (IsNext(row + 1, col, a))
                Dfs((row + 1, col), board[row + 1, col], depth + 1);
            if (IsNext(row - 1, col, a))
                Dfs((row - 1, col), board[row - 1, col], depth + 1);
            if (IsNext(row, col + 1, a))
                Dfs((row, col + 1), board[row, col + 1], depth + 1);
            if (IsNext(row, col - 1, a))
                Dfs((row, col - 1), board[row, col - 1], depth + 1);
            alpha[a - 64] = false;
        }
        static bool IsNext(int row, int col, char a)
        {
            return board[row, col] != a && row <= r && row > 0 && col <= c && col > 0 && !alpha[board[row, col] - 64];
        }
    }
}
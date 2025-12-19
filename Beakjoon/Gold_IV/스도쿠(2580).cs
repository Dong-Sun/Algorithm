using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static int row = 9;
        static int col = 9;
        static int[,] sudoku = new int[row + 2, col + 2];
        static List<(int, int)> pos = new List<(int, int)>();
        static void Main(string[] args)
        {
            string input;
            string[] split;
            for (int i = 1; i <= 9; i++)
            {
                input = Console.ReadLine();
                split = input.Split();
                for (int j = 1; j <= 9; j++)
                {
                    sudoku[i, j] = int.Parse(split[j - 1]);
                    if (sudoku[i, j] == 0)
                        pos.Add((i, j));
                }
            }
            Dfs(0);
            Console.WriteLine(sb);
        }

        static void Dfs(int index)
        {
            if (index >= pos.Count)
            {
                if (sb.Length <= 0)
                {
                    // sudoku 출력
                    for (int i = 1; i <= 9; i++)
                    {
                        for (int j = 1; j <= 9; j++)
                            sb.Append(sudoku[i, j] + " ");

                        sb.Append('\n');
                    }
                }
                return;
            }

            int y = pos[index].Item1;
            int x = pos[index].Item2;
            int[] visited = new int[10];
            // 해당 좌표가 포함된 사각형 범위 내에 숫자들 확인
            // (1,2,3) 을 3으로 나누면 (0, 0, 1)으로 하나씩 밀리기 때문에 -1을 함
            int cntR = (y - 1) / 3;
            int cntC = (x - 1) / 3;
            for (int i = cntR * 3 + 1; i <= cntR * 3 + 3; i++)
            {
                for (int j = cntC * 3 + 1; j <= cntC * 3 + 3; j++)
                    visited[sudoku[i, j]]++;
            }
            // 가로 숫자 확인
            for (int i = 1; i <= 9; i++)
                visited[sudoku[y, i]]++;

            // 세로 숫자 확인
            for (int i = 1; i <= 9; i++)
                visited[sudoku[i, x]]++;

            // 방문하지 않은 숫자들 사용하기
            for (int i = 1; i <= 9; i++)
            {
                if (visited[i] <= 0)
                {
                    sudoku[y, x] = i;
                    Dfs(index + 1);
                    sudoku[y, x] = 0;
                }
            }
        }
    }
}
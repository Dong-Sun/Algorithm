using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new();
        static int R = 12;
        static int C = 6;
        static char[,] board = new char[R + 2, C + 2];
        static bool[,] visited;
        static bool trigger = true;
        static List<(int y, int x)> list = new List<(int y, int x)>();
        static int result = 0;
        static void Main(string[] args)
        {
            // 입력
            for (int i = 1; i <= R; i++)
            {
                string s = Console.ReadLine();
                for (int j = 1; j <= C; j++)
                    board[i, j] = s[j - 1];
            }
            // 구현
            while (trigger)
            {
                trigger = false;
                visited = new bool[R + 2, C + 2];
                for (int y = 1; y <= R; y++)
                    for (int x = 1; x <= C; x++)
                        if (board[y, x] != '.' && !visited[y, x])
                            if (Check(y, x, board[y, x]))
                                Delete();
                if (trigger)
                    Gravity();
            }

            // 출력
            Console.WriteLine(result);
        }
        static bool Check(int ypos, int xpos, char c)
        {
            Queue<(int y, int x)> q = new();
            q.Enqueue((ypos, xpos));
            visited[ypos, xpos] = true;
            list.Clear();
            list.Add(q.Peek());
            while (q.Count > 0)
            {
                var item = q.Dequeue();
                int y = item.y;
                int x = item.x;
                if (y + 1 <= R && !visited[y + 1, x] && board[y + 1, x] == c)
                {
                    q.Enqueue((y + 1, x));
                    visited[y + 1, x] = true;
                    list.Add((y + 1, x));
                }
                if (y - 1 > 0 && !visited[y - 1, x] && board[y - 1, x] == c)
                {
                    q.Enqueue((y - 1, x));
                    visited[y - 1, x] = true;
                    list.Add((y - 1, x));
                }
                if (x + 1 <= C && !visited[y, x + 1] && board[y, x + 1] == c)
                {
                    q.Enqueue((y, x + 1));
                    visited[y, x + 1] = true;
                    list.Add((y, x + 1));
                }
                if (x - 1 > 0 && !visited[y, x - 1] && board[y, x - 1] == c)
                {
                    q.Enqueue((y, x - 1));
                    visited[y, x - 1] = true;
                    list.Add((y, x - 1));
                }
            }
            if (list.Count >= 4)
                return true;
            else
                return false;
        }
        static void Delete()
        {
            trigger = true;
            foreach (var v in list)
                board[v.y, v.x] = '.';
        }
        static void Gravity()
        {
            result++;
            for (int x = 1; x <= C; x++)
            {
                for (int y = R; y > 1; y--)
                {
                    if (board[y, x] == '.')
                    {
                        int ypos = y - 1;
                        while (ypos > 1 && board[ypos, x] == '.')
                            ypos--;
                        if (board[ypos, x] == '.')
                            break;
                        board[y, x] = board[ypos, x];
                        board[ypos, x] = '.';
                    }
                }
            }
        }
    }
}
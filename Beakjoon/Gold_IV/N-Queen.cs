using System.Text;

namespace Debug
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static Func<int[]> InputIntArray = () => Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        static Func<int> InputInt = () => int.Parse(Console.ReadLine());
        static int n;
        static int[,] visited;
        static int result = 0;
        static void Main(string[] args)
        {
            n = InputInt();
            visited = new int[n + 2, n + 2];
            Dfs(1);
            Console.WriteLine(result);
        }
        static void Dfs(int depth)
        {
            if (depth > n)
            {
                result++;
                return;
            }
            for (int i = 1; i <= n; i++)
            {
                if (visited[depth, i] == 0)
                {
                    VisitAdd(depth, i);
                    Dfs(depth + 1);
                    VisitRemove(depth, i);
                }
            }
        }
        static void VisitAdd(int row, int col)
        {
            visited[row, col]++;
            for (int i = 1; row + i <= n; i++)
            {
                visited[row + i, col]++;
                if (col + i <= n)
                    visited[row + i, col + i]++;
                if (col - i > 0)
                    visited[row + i, col - i]++;
            }
        }
        static void VisitRemove(int row, int col)
        {
            visited[row, col]--;
            for (int i = 1; row + i <= n; i++)
            {
                visited[row + i, col]--;
                if (col + i <= n)
                    visited[row + i, col + i]--;
                if (col - i > 0)
                    visited[row + i, col - i]--;
            }
        }
    }
}
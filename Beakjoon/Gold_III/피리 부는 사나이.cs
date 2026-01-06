namespace CSharp
{
    class Program
    {
        static int count = 0;
        static char[,] op;
        static int[,] visited;
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = input[0];
            int m = input[1];
            op = new char[n, m];
            visited = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();
                for (int j = 0; j < m; j++)
                    op[i, j] = str[j];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (visited[i, j] == 0)
                        Dfs(i, j);
                }
            }
            Console.WriteLine(count);
        }
        static void Dfs(int y, int x)
        {
            if (visited[y, x] == 1)
            {
                count++;
            }
            else if (visited[y, x] == 0)
            {
                visited[y, x] = 1;
                switch (op[y, x])
                {
                    case 'U':
                        Dfs(y - 1, x);
                        break;
                    case 'D':
                        Dfs(y + 1, x);
                        break;
                    case 'L':
                        Dfs(y, x - 1);
                        break;
                    case 'R':
                        Dfs(y, x + 1);
                        break;
                }
                visited[y, x] = 2;
            }
        }
    }
}
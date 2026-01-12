using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static StreamReader sr = new StreamReader(Console.OpenStandardInput());
        static int n, m, d;
        static int[,] map;
        static bool[,] visited;
        static bool[,] attacked;
        static int[] archer = new int[3];
        static Queue<(int ypos, int xpos, int distance)> q = new();
        static List<(int ypos, int xpos, int distance)> list = new();
        static int result = 0;
        static int enemyCount = 0;
        static void Main(string[] args)
        {
            // 입력
            int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            n = input[0]; m = input[1]; d = input[2];
            map = new int[n + 2, m + 2];
            for (int i = 0; i < n; i++)
            {
                input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int j = 0; j < m; j++)
                {
                    map[i + 1, j + 1] = input[j];
                    if (input[j] == 1)
                        enemyCount++;
                }
            }

            // 구현
            Dfs(0, 0);

            // 출력
            Console.WriteLine(result);
        }
        static void Dfs(int cur, int depth)
        {
            if (depth == 3)
            {
                int temp = 0;
                int ignore = 0;
                attacked = new bool[n + 2, m + 2];
                for (int y = n; y > 0; y--)
                {
                    if (temp + ignore >= enemyCount) break;
                    list.Clear();
                    for (int i = 0; i < 3; i++)
                    {
                        q.Clear();
                        visited = new bool[n + 2, m + 2];
                        q.Enqueue((y, archer[i], 1));
                        while (q.Count > 0)
                        {
                            var item = q.Dequeue();
                            if (map[item.ypos, item.xpos] == 1 && attacked[item.ypos, item.xpos] == false)
                            {
                                list.Add((item.ypos, item.xpos, item.distance));
                                break;
                            }
                            if (item.distance + 1 > d) continue;
                            if (item.xpos - 1 > 0)
                            {
                                q.Enqueue((item.ypos, item.xpos - 1, item.distance + 1));
                                visited[item.ypos, item.xpos - 1] = true;
                            }
                            if (item.ypos - 1 > 0)
                            {
                                q.Enqueue((item.ypos - 1, item.xpos, item.distance + 1));
                                visited[item.ypos - 1, item.xpos] = true;
                            }
                            if (item.xpos + 1 <= m)
                            {
                                q.Enqueue((item.ypos, item.xpos + 1, item.distance + 1));
                                visited[item.ypos, item.xpos + 1] = true;
                            }
                        }
                    }
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (map[list[i].ypos, list[i].xpos] == 1 && attacked[list[i].ypos, list[i].xpos] == false)
                        {
                            attacked[list[i].ypos, list[i].xpos] = true;
                            temp++;
                        }
                    }
                    for (int i = 1; i <= m; i++)
                    {
                        if (map[y, i] == 1 && attacked[y, i] == false)
                            ignore++;
                    }
                }
                result = Math.Max(result, temp);
                return;
            }
            else
            {
                for (int next = cur + 1; next <= m - 2 + depth; next++)
                {
                    archer[depth] = next;
                    Dfs(next, depth + 1);
                }
            }
        }
    }
}
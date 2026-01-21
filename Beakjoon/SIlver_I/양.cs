int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int R = input[0];
int C = input[1];
char[,] map = new char[R + 2, C + 2];
int sheepCount = 0;
int wolfCount = 0;
for (int i = 1; i <= R; i++)
{
    string s = Console.ReadLine();
    for (int j = 1; j <= C; j++)
    {
        map[i, j] = s[j - 1];
        if (map[i, j] == 'o')
            sheepCount += 1;
        else if (map[i, j] == 'v')
            wolfCount += 1;
    }
}
bool[,] visited = new bool[R + 2, C + 2];
int[] dy = { -1, 1, 0, 0 };
int[] dx = { 0, 0, -1, 1 };

for (int y = 1; y <= R; y++)
{
    for (int x = 1; x <= C; x++)
    {
        if (visited[y, x])
            continue;
        if (map[y, x] == '.' || map[y, x] == '#')
            continue;

        Queue<(int y, int x)> q = new Queue<(int y, int x)>();
        q.Enqueue((y, x));
        visited[y, x] = true;
        int sheep = 0;
        int wolf = 0;
        while (q.Count > 0)
        {
            var cur = q.Dequeue();
            int cy = cur.y;
            int cx = cur.x;
            if (map[cy, cx] == 'o')
                sheep += 1;
            else if (map[cy, cx] == 'v')
                wolf += 1;
            for (int i = 0; i < 4; i++)
            {
                int ny = cy + dy[i];
                int nx = cx + dx[i];
                if (ny > R || ny < 1 || nx > C || nx < 1)
                    continue;
                if (map[ny, nx] == '#')
                    continue;
                if (visited[ny, nx])
                    continue;
                q.Enqueue((ny, nx));
                visited[ny, nx] = true;
            }
        }
        if (sheep > wolf)
            wolfCount -= wolf;
        else
            sheepCount -= sheep;
    }
}
Console.WriteLine("{0} {1}", sheepCount, wolfCount);
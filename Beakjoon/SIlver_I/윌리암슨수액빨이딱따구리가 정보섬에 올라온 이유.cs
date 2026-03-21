int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int[,] table = new int[n + 2, m + 2];
int sy = -1;
int sx = -1;
for (int i = 1; i <= n; i++)
{
    string s = Console.ReadLine();
    for (int j = 1; j <= m; j++)
    {
        table[i, j] = s[j - 1] - 48;
        if (table[i, j] == 2)
        {
            sy = i;
            sx = j;
        }
    }
}

int[] dy = { 1, -1, 0, 0 };
int[] dx = { 0, 0, 1, -1 };
int[,] distance = new int[n + 2, m + 2];
Queue<(int y, int x)> q = new Queue<(int y, int x)>();
q.Enqueue((sy, sx));
while (q.Count > 0)
{
    var cur = q.Dequeue();
    int cy = cur.y;
    int cx = cur.x;
    if (table[cy, cx] == 3 || table[cy, cx] == 4 || table[cy, cx] == 5)
    {
        Console.WriteLine("TAK");
        Console.WriteLine(distance[cy, cx]);
        return;
    }
    for (int i = 0; i < 4; i++)
    {
        int ny = cy + dy[i];
        int nx = cx + dx[i];
        if (ny < 1 || ny > n || nx < 1 || nx > m)
            continue;
        if (distance[ny, nx] != 0 || table[ny, nx] == 1)
            continue;
        q.Enqueue((ny, nx));
        distance[ny, nx] = distance[cy, cx] + 1;
    }
}
Console.WriteLine("NIE");
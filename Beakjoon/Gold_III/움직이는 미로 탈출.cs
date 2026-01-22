char[,] board = new char[10, 10];   // 체스판
for (int i = 1; i <= 8; i++)
{
    string s = Console.ReadLine();
    for (int j = 1; j <= 8; j++)
    {
        board[i, j] = s[j - 1];
    }
}
// 제자리 + 8방향 설정
int[] dy = { 0, -1, -1, 0, 1, 1, 1, 0, -1 };
int[] dx = { 0, 0, 1, 1, 1, 0, -1, -1, -1 };

// 좌측 하단에서 부터 bfs
int sy = 8;
int sx = 1;
Queue<(int y, int x, int second)> q = new();
q.Enqueue((sy, sx, 0));
int[,] visited = new int[10, 10];
int time = 0;
bool flag = false;
while (flag == false && q.Count > 0)
{
    while (q.Count > 0 && q.Peek().second == time)
    {
        var cur = q.Dequeue();
        int cy = cur.y;
        int cx = cur.x;
        int s = cur.second;
        if (board[cy, cx] == '#')
            continue;
        if (cy == 1 && cx == 8)
        {
            flag = true;
            break;
        }
        for (int i = 0; i < 9; i++)
        {
            int ny = cy + dy[i];
            int nx = cx + dx[i];
            if (ny > 8 || ny < 1 || nx > 8 || nx < 1)
                continue;
            if (board[ny, nx] == '.' && visited[ny, nx] < s + 1)
            {
                q.Enqueue((ny, nx, s + 1));
                visited[ny, nx] = s + 1;
            }
        }
    }
    if (flag == false)
    {
        Gravity();
        time += 1;
    }
}
if (flag)
    Console.WriteLine("1");
else
    Console.WriteLine("0");

void Gravity()
{
    for (int y = 8; y >= 1; y--)
    {
        for (int x = 1; x <= 8; x++)
        {
            if (board[y, x] == '#')
            {
                board[y + 1, x] = board[y, x];
                board[y, x] = '.';
            }
        }
    }
}
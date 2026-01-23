int n = int.Parse(Console.ReadLine());
int[,] board = new int[n + 2, n + 2];
for (int i = 1; i <= n; i++)
{
    int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 1; j <= n; j++)
    {
        board[i, j] = input[j - 1];
    }
}

int[] direction = new int[5];
// 상 하 좌 우
int[] dy = { -1, 1, 0, 0 };
int[] dx = { 0, 0, -1, 1 };
int result = 0;
for (int i = 0; i < 4; i++)
{
    Dfs((int[,])board.Clone(), i, 1);
}
Console.WriteLine(result);

void Dfs(int[,] arr, int dir, int depth)
{
    direction[depth - 1] = dir;
    Move(arr, dir);
    if (depth == 5)
    {
        result = Math.Max(result, Max(arr));
        return;
    }
    for (int i = 0; i < 4; i++)
    {
        Dfs((int[,])arr.Clone(), i, depth + 1);
    }
    direction[depth - 1] = 0;
}
void Swap(int[,] arr, int y1, int x1, int y2, int x2)
{
    int temp = arr[y1, x1];
    arr[y1, x1] = arr[y2, x2];
    arr[y2, x2] = temp;
}
bool OutRange(int y, int x)
{
    if (y > n || y < 1 || x > n || x < 1)
        return true;
    else
        return false;
}
void Move(int[,] arr, int dir)
{
    int sy = 1;
    int sx = 1;
    bool[,] flag = new bool[n + 2, n + 2];
    switch (dir)
    {
        case 1:
            sy = n;
            break;
        case 3:
            sx = n;
            break;
    }
    int my = sy == 1 ? 1 : -1;
    int mx = sx == 1 ? 1 : -1;
    for (int y = sy; y <= n && y >= 1; y += my)
    {
        for (int x = sx; x <= n && x >= 1; x += mx)
        {
            int ny = y + dy[dir];
            int nx = x + dx[dir];
            // 앞이 빈칸인 경우 최대한 당겨준다.
            while (!OutRange(ny, nx) && arr[ny, nx] == 0)
            {
                ny += dy[dir];
                nx += dx[dir];
            }
            ny -= dy[dir];
            nx -= dx[dir];
            Swap(arr, ny, nx, y, x);
            if (flag[ny + dy[dir], nx + dx[dir]])
                continue;
            if (!OutRange(ny + dy[dir], nx + dx[dir]) && arr[ny + dy[dir], nx + dx[dir]] == arr[ny, nx])
            {
                int sum = arr[ny, nx] * 2;
                arr[ny + dy[dir], nx + dx[dir]] = sum;
                arr[ny, nx] = 0;
                flag[ny + dy[dir], nx + dx[dir]] = true;
            }
        }
    }
}
int Max(int[,] arr)
{
    int max = 0;
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            max = Math.Max(max, arr[i, j]);
        }
    }
    return max;
}
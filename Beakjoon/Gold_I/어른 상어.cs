// 입력
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];   // 격자의 크기
int m = input[1];   // 상어의 개수
int k = input[2];   // 냄새 지속시간
int[,] table = new int[n + 2, n + 2];   // 상어 냄새
int[,] time = new int[n + 2, n + 2];    // 해당 좌표 냄새 지속시간
bool[] dead = new bool[m + 1];  // 해당 번호 상어 생존 여부
bool[,] visited = new bool[n + 2, n + 2];
(int y, int x)[] shark = new (int y, int x)[m + 1]; // 해당 번호 상어 위치
for (int i = 1; i <= n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 1; j <= n; j++)
    {
        table[i, j] = input[j - 1];
        if (table[i, j] != 0)
        {
            time[i, j] = k;
            shark[table[i, j]] = (i, j);
            visited[i, j] = true;
        }
    }
}
// 상 하 좌 우
int[] dy = { 0, -1, 1, 0, 0 };
int[] dx = { 0, 0, 0, -1, 1 };
int[] direction = new int[m + 1];   // 해당 번호 상어가 보고 있는 방향
int[,,] priority = new int[m + 1, 5, 4];   // 상어 번호, 현재 방향, 우선순위위
input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
for (int i = 1; i <= m; i++)
    direction[i] = input[i - 1];
for (int i = 1; i <= m; i++)
{
    for (int j = 1; j <= 4; j++)
    {
        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        for (int p = 0; p < 4; p++)
            priority[i, j, p] = input[p];
    }
}
// 구현
int count = 0;
bool one = false;
while (true)
{
    // 1번을 제외한 모든 상어가 쫓겨남
    one = true;
    for (int i = 2; i <= m; i++)
    {
        if (!dead[i])
            one = false;
    }
    if (one)
        break;

    // 1000번을 넘게 이동해도 다른 상어가 격자에 남음
    count++;
    if (count > 1000)
    {
        count = -1;
        break;
    }

    // 살아있는 상어들 이동
    for (int i = 1; i <= m; i++)
    {
        if (dead[i])
            continue;
        // 현재 좌표 정보
        int cy = shark[i].y;
        int cx = shark[i].x;

        // 현재 보고있는 방향을 기준 잡음
        int d = direction[i];
        // 우선순위에 따라서 인접 칸이 빈칸인지 확인
        bool move = false;
        for (int j = 0; j < 4; j++)
        {
            int dir = priority[i, d, j];
            int ny = cy + dy[dir];
            int nx = cx + dx[dir];
            if (ny > n || ny < 1 || nx > n || nx < 1)   // 범위 벗어남
                continue;
            if (visited[ny, nx])    // 기존에 냄새가 남아있음
                continue;
            if (time[ny, nx] == k + 1)
            {
                // 오름차순 탐색이기에 이미 방문한 상어 번호가 무조건 더 낮음
                // 상어 죽음, 다음 번호 상어로 이동
                dead[i] = true;
                break;
            }
            else if (table[ny, nx] == 0)
            {
                // 빈칸 찾으면 이동
                shark[i].y = ny;
                shark[i].x = nx;
                direction[i] = dir;
                table[ny, nx] = i;
                time[ny, nx] = k + 1;
                move = true;
                break;
            }
        }
        if (dead[i] || move)
            continue;
        // 이동이 없었다면 주변 자신 냄새를 찾아서 이동
        for (int j = 0; j < 4; j++)
        {
            int dir = priority[i, d, j];
            int ny = cy + dy[dir];
            int nx = cx + dx[dir];
            if (ny > n || ny < 1 || nx > n || nx < 1)
                continue;
            if (table[ny, nx] == i)
            {
                // 빈칸 찾으면 이동
                shark[i].y = ny;
                shark[i].x = nx;
                direction[i] = dir;
                table[ny, nx] = i;
                time[ny, nx] = k + 1;
                move = true;
                break;
            }
        }
    }
    // 냄새 빼기
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            time[i, j]--;
            if (time[i, j] <= 0)
            {
                table[i, j] = 0;
                visited[i, j] = false;
            }
            else
                visited[i, j] = true;
        }
    }
}

// 출력
Console.WriteLine(count);
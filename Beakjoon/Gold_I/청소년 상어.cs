// 입력
int[] dy = { 0, -1, -1, 0, 1, 1, 1, 0, -1 };
int[] dx = { 0, 0, -1, -1, -1, 0, 1, 1, 1 };
int R = 4;
int C = 4;
int[,,] table = new int[R + 2, C + 2, 17];
int[,,] direction = new int[R + 2, C + 2, 17];
bool[,] shark = new bool[R + 2, C + 2];
for (int i = 1; i <= R; i++)
{
    string s = Console.ReadLine();
    string[] split = s.Split();
    for (int j = 0; j < split.Length; j += 2)
    {
        table[i, j / 2 + 1, 0] = int.Parse(split[j]);
        direction[i, j / 2 + 1, 0] = int.Parse(split[j + 1]);
    }
}

// 구현
int max = 0;
Dfs(1, 1, 0, 1);
void Dfs(int y, int x, int result, int depth)
{
    // 이전 depth 좌표 복사
    for (int ypos = 1; ypos <= R; ypos++)
    {
        for (int xpos = 1; xpos <= C; xpos++)
        {
            table[ypos, xpos, depth] = table[ypos, xpos, depth - 1];
            direction[ypos, xpos, depth] = direction[ypos, xpos, depth - 1];
        }
    }
    // 받은 좌표로 상어가 먹으면서 입장
    int num = result + table[y, x, depth];
    max = Math.Max(max, num);
    table[y, x, depth] = 0;
    shark[y, x] = true;
    // 물고기 이동
    for (int i = 1; i <= 16; i++)
    {
        // 해당 번호 물고기 찾기
        int cy = 0;
        int cx = 0;
        bool find = false;
        for (int ypos = 1; ypos <= R; ypos++)
        {
            if (find) break;
            for (int xpos = 1; xpos <= C; xpos++)
            {
                if (find) break;
                if (table[ypos, xpos, depth] == i)
                {
                    cy = ypos;
                    cx = xpos;
                    find = true;
                }
            }
        }
        if (!find) continue;
        // 해당 물고기가 이동 가능한 방향 찾기
        for (int j = 0; j < 8; j++)
        {
            int d = direction[cy, cx, depth];
            int ny = cy + dy[d];
            int nx = cx + dx[d];
            // 공간을 벗어나는 경우, 해당 칸에 상어가 있는 경우
            if (ny < 1 || ny > R || nx < 1 || nx > C || shark[ny, nx])
            {
                direction[cy, cx, depth]++;
                if (direction[cy, cx, depth] == 9)
                    direction[cy, cx, depth] = 1;
                continue;
            }
            // 두 자리 물고기 위치, 방향 변경
            int temp = table[ny, nx, depth];
            table[ny, nx, depth] = table[cy, cx, depth];
            table[cy, cx, depth] = temp;

            temp = direction[ny, nx, depth];
            direction[ny, nx, depth] = direction[cy, cx, depth];
            direction[cy, cx, depth] = temp;
            break;
        }
    }

    // 현 좌표에 있는 방향을 기준으로 상어가 갈수있는 곳 탐색
    shark[y, x] = false;
    int dir = direction[y, x, depth];
    int sy = y + dy[dir];
    int sx = x + dx[dir];
    while (sy <= R && sy >= 1 && sx <= C && sx >= 1)
    {
        if (table[sy, sx, depth] != 0)
            Dfs(sy, sx, num, depth + 1);
        sy += dy[dir];
        sx += dx[dir];
    }
}
// 출력
Console.WriteLine(max);
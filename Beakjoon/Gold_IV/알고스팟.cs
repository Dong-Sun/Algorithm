// 입력
string line = Console.ReadLine();
string[] split = line.Split();
int n = int.Parse(split[1]);
int m = int.Parse(split[0]);
int[,] miro = new int[n + 2, m + 2];
int[,] visited = new int[n + 2, m + 2];
for (int i = 1; i <= n; i++)
{
    line = Console.ReadLine();
    for (int j = 1; j <= m; j++)
    {
        miro[i, j] = int.Parse(line[j - 1].ToString());
        visited[i, j] = int.MaxValue;
    }
}
// 구현
Queue<(int y, int x)> q = new();
q.Enqueue((1, 1));
visited[1, 1] = 0;
int result = int.MaxValue;
int[] dy = { 1, 0, -1, 0 };
int[] dx = { 0, 1, 0, -1 };
while (q.Count > 0)
{
    var pos = q.Dequeue();
    if (pos.y == n && pos.x == m)
    {
        result = Math.Min(result, visited[n, m]);
        continue;
    }
    for (int i = 0; i < 4; i++)
    {
        if (pos.y + dy[i] > n || pos.y + dy[i] < 1 || pos.x + dx[i] > m || pos.x + dx[i] < 1)
            continue;
        if (miro[pos.y + dy[i], pos.x + dx[i]] + visited[pos.y, pos.x] < visited[pos.y + dy[i], pos.x + dx[i]])
        {
            q.Enqueue((pos.y + dy[i], pos.x + dx[i]));
            visited[pos.y + dy[i], pos.x + dx[i]] = visited[pos.y, pos.x] + miro[pos.y + dy[i], pos.x + dx[i]];
        }
    }
}
// 출력
Console.WriteLine(result);
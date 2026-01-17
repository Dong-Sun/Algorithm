// 입력
int n = int.Parse(Console.ReadLine());
int[,] map = new int[n + 2, n + 2];
int[,] dp = new int[n + 2, n + 2];
for (int i = 1; i <= n; i++)
{
    int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 1; j <= n; j++)
        map[i, j] = input[j - 1];
}
// 구현
int[] dy = { -1, 1, 0, 0 };
int[] dx = { 0, 0, -1, 1 };

int result = 0;
for (int y = 1; y <= n; y++)
    for (int x = 1; x <= n; x++)
        result = Math.Max(result, Dfs(y, x));

int Dfs(int y, int x)
{
    if (dp[y, x] <= 0)
    {
        int temp = 1;
        int count = 1;
        for (int i = 0; i < 4; i++)
        {
            if (map[y, x] < map[y + dy[i], x + dx[i]])
                count += Dfs(y + dy[i], x + dx[i]);
            temp = Math.Max(temp, count);
            count = 1;
        }
        dp[y, x] = temp;
    }
    return dp[y, x];
}
// 출력
Console.WriteLine(result);
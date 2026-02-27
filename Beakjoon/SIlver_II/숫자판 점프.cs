using System.Text;

char[,] table = new char[5, 5];
for (int i = 0; i < 5; i++)
{
    char[] input = Array.ConvertAll(Console.ReadLine().Split(), char.Parse);
    for (int j = 0; j < 5; j++)
        table[i, j] = input[j];
}

int result = 0;
StringBuilder sb = new StringBuilder();
char[] save = new char[6];
HashSet<string> flag = new HashSet<string>();
int[] dy = { 1, -1, 0, 0 };
int[] dx = { 0, 0, 1, -1 };
for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < 5; j++)
        Dfs(i, j, 0);
}
Console.WriteLine(result);

void Dfs(int y, int x, int depth)
{
    save[depth] = table[y, x];
    if (depth == 5)
    {
        sb.Clear();
        foreach (var v in save)
            sb.Append(v);
        if (flag.Add(sb.ToString()))
            result++;
        return;
    }
    for (int i = 0; i < 4; i++)
    {
        int ny = y + dy[i];
        int nx = x + dx[i];
        if (ny < 0 || ny >= 5 || nx < 0 || nx >= 5)
            continue;
        Dfs(ny, nx, depth + 1);
    }
}
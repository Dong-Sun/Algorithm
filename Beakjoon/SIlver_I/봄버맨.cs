using System.Text;

int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int r = input[0];
int c = input[1];
int n = input[2];
int[] dy = { -1, 1, 0, 0 };
int[] dx = { 0, 0, -1, 1 };
char[,] table = new char[r + 2, c + 2];
int[,] time = new int[r + 2, c + 2];
for (int i = 1; i <= r; i++)
{
    string s = Console.ReadLine();
    for (int j = 1; j <= c; j++)
    {
        table[i, j] = s[j - 1];
        if (table[i, j] == 'O')
            time[i, j] = 2;
    }
}

Queue<(int y, int x)> q = new Queue<(int y, int x)>();
bool flag = true;
while (n-- > 1)
{
    if (flag)
    {
        for (int i = 1; i <= r; i++)
        {
            for (int j = 1; j <= c; j++)
            {
                if (time[i, j] == 0)
                {
                    time[i, j] = 3;
                    table[i, j] = 'O';
                }
                else
                {
                    time[i, j]--;
                }
            }
        }
    }
    else
    {
        for (int i = 1; i <= r; i++)
        {
            for (int j = 1; j <= c; j++)
            {
                time[i, j]--;
                if (time[i, j] == 0)
                {
                    q.Enqueue((i, j));
                }
            }
        }
        while (q.Count > 0)
        {
            var v = q.Dequeue();
            Boom(v.y, v.x);
        }
    }
    flag = !flag;
}

StringBuilder result = new StringBuilder();
for (int i = 1; i <= r; i++)
{
    for (int j = 1; j <= c; j++)
    {
        result.Append(table[i, j]);
    }
    result.AppendLine();
}
Console.Write(result);


void Boom(int y, int x)
{
    time[y, x] = 0;
    table[y, x] = '.';
    for (int i = 0; i < 4; i++)
    {
        int ny = y + dy[i];
        int nx = x + dx[i];
        if (ny > r || ny < 1 || nx > c || nx < 1)
            continue;

        time[ny, nx] = 0;
        table[ny, nx] = '.';
    }
}
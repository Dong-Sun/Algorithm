// input
using System.Text;

int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int r = input[0];
int c = input[1];

char[,] table = new char[r + 2, c + 2];
List<(int y, int x)> list = new();
for (int i = 1; i <= r; i++)
{
    string s = Console.ReadLine();
    for (int j = 1; j <= c; j++)
    {
        table[i, j] = s[j - 1];
        if (table[i, j].Equals('S'))
            list.Add((i, j));
    }
}

// solution
int[] dy = { -1, 1, 0, 0 };
int[] dx = { 0, 0, -1, 1 };
foreach (var v in list)
{
    bool find = false;
    for (int i = 0; i < 4; i++)
    {
        int cy = v.y + dy[i];
        int cx = v.x + dx[i];
        if (cy < 1 || cy > r || cx < 1 || cx > c)
            continue;
        if (table[cy, cx].Equals('W'))
            find = true;
        else if (table[cy, cx].Equals('.'))
            table[cy, cx] = 'D';
    }
    if (find)
    {
        Console.WriteLine("0");
        return;
    }
}

// print
StringBuilder sb = new StringBuilder();
for (int i = 1; i <= r; i++)
{
    for (int j = 1; j <= c; j++)
        sb.Append(table[i, j]);
    sb.AppendLine();
}
Console.WriteLine("1");
Console.Write(sb);
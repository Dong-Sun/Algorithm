using System.Text;

StringBuilder sb = new();
List<int> list = new();
while (true)
{
    string s = Console.ReadLine();
    if (s == null || s.Equals(""))
        break;
    list.Add(int.Parse(s));
}
char[] str;
foreach (int n in list)
{
    int length = 1;
    for (int i = 0; i < n; i++)
        length *= 3;
    str = new char[length];
    for (int i = 0; i < length; i++)
        str[i] = '-';
    Dfs(0, length, length);
    for (int i = 0; i < length; i++)
        sb.Append(str[i]);
    sb.AppendLine();
}
Console.Write(sb);

void Dfs(int start, int end, int n)
{
    if (start - end == 1)
        return;
    if (n <= 1)
        return;
    int temp = (end - start) / 3;
    for (int s = start + temp; s < end - temp; s++)
        str[s] = ' ';
    Dfs(start, start + temp, n / 3);
    Dfs(end - temp, end, n / 3);
}
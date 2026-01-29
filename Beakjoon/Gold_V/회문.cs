using System.Text;

StringBuilder sb = new();
int n = int.Parse(Console.ReadLine());
while (n-- > 0)
{
    string s = Console.ReadLine();
    int result = Search(0, s.Length - 1, false, s);
    sb.AppendLine(result.ToString());
}
Console.WriteLine(sb);

int Search(int _left, int _right, bool flag, string s)
{
    int left = _left;
    int right = _right;
    while (left < right)
    {
        if (!s[left].Equals(s[right]))
            break;

        left += 1;
        right -= 1;
    }
    if (left >= right)
    {
        if (flag)
            return 1;
        else
            return 0;
    }
    else
    {
        if (flag)
            return 2;
        else
            return Math.Min(Search(left + 1, right, true, s), Search(left, right - 1, true, s));
    }
}
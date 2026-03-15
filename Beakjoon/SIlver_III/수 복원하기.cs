using System.Text;

bool[] flag = new bool[100001];
for (int i = 2; i <= 100000; i++)
{
    if (flag[i]) continue;
    for (int j = i + i; j <= 100000; j += i)
    {
        flag[j] = true;
    }
}
List<int> list = new List<int>();
for (int i = 2; i <= 100000; i++)
{
    if (!flag[i]) list.Add(i);
}

StringBuilder result = new StringBuilder();
int t = int.Parse(Console.ReadLine());
while (t-- > 0)
{
    int n = int.Parse(Console.ReadLine());
    foreach (var v in list)
    {
        int num = v;
        int count = 0;
        while (n > 1 && n % v == 0)
        {
            count++;
            n /= v;
        }
        if (count > 0)
            result.AppendLine(num + " " + count);
        if (n <= 1) break;
    }
}
Console.WriteLine(result);
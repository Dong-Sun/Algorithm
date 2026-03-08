using System.Text;

double size = 0;
Dictionary<string, int> dict = new Dictionary<string, int>();
while (true)
{
    string s = Console.ReadLine();
    if (s == null || s.Equals(""))
        break;

    if (!dict.ContainsKey(s))
        dict.Add(s, 0);
    dict[s]++;
    size++;
}

List<(string key, double value)> list = new List<(string, double)>();
foreach (var v in dict)
    list.Add((v.Key, v.Value / size * 100f));
list.Sort((left, right) =>
{
    return left.key.CompareTo(right.key);
});

StringBuilder sb = new StringBuilder();
foreach (var v in list)
    sb.AppendLine(v.key + " " + string.Format("{0:F4}", v.value));
Console.Write(sb);